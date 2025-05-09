using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCardsMechanic : MonoBehaviour
{
    private Camera mainCamera;
    private Card selectedCard;
    private Vector3 offset;
    private Vector3 originalPosition;
    private Pile originalPile;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TryBeginDrag();
        if (selectedCard != null)
        {
            if (Input.GetMouseButton(0))
                ContinueDrag();
            if (Input.GetMouseButtonUp(0))
                EndDrag();
        }
    }

    void TryBeginDrag()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(mousePos);
        if (hit != null && hit.TryGetComponent<Card>(out selectedCard))
        {
            originalPosition = selectedCard.transform.position;
            originalPile = selectedCard.CurrentPile;
            Vector3 cardPos = selectedCard.transform.position;
            offset = cardPos - new Vector3(mousePos.x, mousePos.y, cardPos.z);
        }
        else selectedCard = null;
    }

    void ContinueDrag()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        selectedCard.transform.position = new Vector3(mousePos.x, mousePos.y, selectedCard.transform.position.z) + offset;
    }

    void EndDrag()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] hits = Physics2D.OverlapPointAll(mousePos);
        Pile target = null;
        foreach (var hit in hits) if (hit.TryGetComponent<Pile>(out target)) break;

        if (target != null && target != originalPile)
        {
            var cardMoveEventData = new CardMovedEventData
            {
                card = selectedCard,
                targetPile = target
            };
            EventBus.RaiseOnCardMoved(cardMoveEventData);
        }
        else
            selectedCard.transform.position = originalPosition;

        selectedCard = null;
    }
}

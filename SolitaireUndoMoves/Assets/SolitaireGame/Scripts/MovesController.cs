using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovesController : MonoBehaviour
{

    private List<MoveData> moves = new List<MoveData>();

    private void OnEnable()
    {
        EventBus.OnCardMoved += OnCardMoved;
        EventBus.OnUndoMove += OnUndoMove;
    }

    private void OnDisable()
    {
        EventBus.OnCardMoved -= OnCardMoved;
        EventBus.OnUndoMove -= OnUndoMove;
    }

    private void OnCardMoved(CardMovedEventData eventData)
    {
        if (eventData.isUndoing)
            return;

        var moveData = new MoveData
        {
            cards = new List<CardData> { eventData.card.CardData },
            fromPile = eventData.card.CurrentPile.PileName,
            toPile = eventData.targetPile,
        };

        moves.Add(moveData);
    }

    private void OnUndoMove()
    {
        if (moves.Count == 0)
            return;

        var moveData = moves[moves.Count - 1];
        moves.RemoveAt(moves.Count - 1);

        var cardMoveEventData = new CardMovedEventData
        {
            card = moveData.cards[0].card,
            targetPile = moveData.fromPile,
            isUndoing = true,
        };
        EventBus.RaiseOnCardMoved(cardMoveEventData);
        
    }
}

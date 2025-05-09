using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cardsParent;

    [Space]
    [Header("Data")]
    public PileName PileName;

    public int Id => (int)PileName;

    private List<Card> cards = new List<Card>();

    private void OnEnable()
    {
        EventBus.OnCardMoved += OnCardMoved;
    }

    private void OnDisable()
    {
        EventBus.OnCardMoved -= OnCardMoved;
    }

    private void OnCardMoved(CardMovedEventData eventData)
    {
        if (eventData.targetPile != this)
            return;

        AddCards(new List<Card> { eventData.card });
    }

    public void Initialize(List<Card> addingCards)
    {
        AddCards(addingCards);

        if (PileName == PileName.TableauPile1 ||
            PileName == PileName.TableauPile2 ||
            PileName == PileName.TableauPile3)
        {
            addingCards[addingCards.Count - 1].SetFront();
        }
    }

    public void AddCards(List<Card> addingCards)
    {
        cards.AddRange(addingCards);

        foreach (var addingCard in addingCards)
        {
            addingCard.CurrentPile = this;
            addingCard.transform.parent = cardsParent;
            addingCard.transform.localPosition = Vector3.zero;

            switch (PileName)
            {
                case PileName.DrawPile:
                    addingCard.SetBack();
                    break;

                case PileName.WastePile:
                    addingCard.SetFront();
                    break;

                case PileName.FoundationPileSpades:
                case PileName.FoundationPileDiamonds:
                case PileName.FoundationPileHearts:
                case PileName.FoundationPileClubs:
                    addingCard.SetFront();
                    break;

                case PileName.TableauPile1:
                case PileName.TableauPile2:
                case PileName.TableauPile3:

                    addingCard.SetBack();
                    break;
            }

        }

        ReSortOrderCards();
    }

    public void RemoveCards(List<Card> removingCards)
    {
        foreach (Card removingCard in removingCards) 
        {
            cards.Remove(removingCard);
        }

        ReSortOrderCards();
    }

    private void ReSortOrderCards()
    {
        int sortOrder = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            sortOrder = sortOrder + 2;
            cards[i].SetSortOrder(sortOrder);
        }
    }
}

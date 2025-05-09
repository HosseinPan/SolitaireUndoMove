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

    public void Initialize(List<Card> addingCards)
    {
        AddCards(addingCards);

        if (PileName == PileName.TableauPile1 ||
            PileName == PileName.TableauPile2 ||
            PileName == PileName.TableauPile3)
        {
            addingCards[addingCards.Count - 1].SetFront();
        }

        foreach (var addingCard in addingCards)
            addingCard.transform.localPosition = Vector3.zero;
    }

    public void AddCards(List<Card> addingCards)
    {
        cards.AddRange(addingCards);

        foreach (var addingCard in addingCards)
        {
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

            addingCard.transform.parent = cardsParent;
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
            sortOrder = i + 2;
            cards[i].SetSortOrder(sortOrder);
        }
    }
}

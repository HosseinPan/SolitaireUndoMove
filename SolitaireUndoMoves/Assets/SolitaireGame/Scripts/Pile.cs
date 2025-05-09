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
        switch (PileName) 
        {
            case PileName.DrawPile:
                foreach (Card card in addingCards)
                    card.SetBack();
                break;

            case PileName.WastePile:
                foreach (Card card in addingCards)
                    card.SetFront();
                break;

            case PileName.FoundationPileSpades:
            case PileName.FoundationPileDiamonds:
            case PileName.FoundationPileHearts:
            case PileName.FoundationPileClubs:
                foreach (Card card in addingCards)
                    card.SetFront();
                break;

            case PileName.TableauPile1:
            case PileName.TableauPile2:
            case PileName.TableauPile3:

                foreach (Card card in addingCards)
                    card.SetBack();
                addingCards[addingCards.Count - 1].SetFront();

                break;
        }
    }

    public void AddCards(List<Card> addingCards)
    {
        cards.AddRange(addingCards);
    }

    public void RemoveCards(List<Card> removingCards)
    {
        foreach (Card removingCard in removingCards) 
        {
            cards.Remove(removingCard);
        }       
    }
}

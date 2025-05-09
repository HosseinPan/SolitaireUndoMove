using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Card cardPrefab;

    private const int cardsCountInEachSuit = 13;
    private List<Card> cards = new List<Card>();
    private int cardIdCounter = 0;

    void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        InitializeCards();
        InitializePiles();
    }

    private void InitializeCards()
    {
        InitializeCardBySuit(CardSuit.Diamonds);
        InitializeCardBySuit(CardSuit.Hearts);
        InitializeCardBySuit(CardSuit.Clubs);
        InitializeCardBySuit(CardSuit.Spades);
        ShuffleCards();
    }

    private void InitializeCardBySuit(CardSuit cardSuit)
    {
        for (int i = 1; i <= cardsCountInEachSuit; i++)
        {
            cardIdCounter++;
            var cardData = new CardData()
            {
                Id = cardIdCounter,
                Number = i,
                Suit = cardSuit
            };
            var card = Instantiate<Card>(cardPrefab);
            card.Initialize(cardData);
            cards.Add(card);
        }
    }

    private void ShuffleCards()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            var temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    private void InitializePiles()
    {
        var initializePilesData = new InitializePileEventData
        {
            cards = cards,
        };

        EventBus.RaiseOnInitializePiles(initializePilesData);
    }

}

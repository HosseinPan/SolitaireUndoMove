using System;

[Serializable]
public class CardData
{
    public int Id;
    public CardSuit Suit;
    public int Number;
    public Card card;
}

public enum CardSuit
{
    Spades,
    Hearts,
    Diamonds,
    Clubs
}

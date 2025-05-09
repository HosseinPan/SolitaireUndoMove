using System;

[Serializable]
public class CardData
{
    public int Id;
    public CardSuit Suit;
    public int Number;
    public string Title;
}

public enum CardSuit
{
    Spades,
    Hearts,
    Diamonds,
    Clubs
}

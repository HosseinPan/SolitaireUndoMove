using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject backCard;
    [SerializeField] private GameObject frontCard;
    public TMP_Text numberText;
    public TMP_Text suitText;

    [Space]
    [Header("Data")]
    [SerializeField] private CardData cardData;


    public void Initialize(CardData data)
    {
        cardData = data;

        backCard.SetActive(true);
        frontCard.SetActive(false);

        switch(data.Suit)
        {
            case CardSuit.Spades:
                suitText.text = "S";
                break;

            case CardSuit.Hearts:
                suitText.text = "H";
                break;

            case CardSuit.Diamonds:
                suitText.text = "D";
                break;

            case CardSuit.Clubs:
                suitText.text = "C";
                break;
        }

        if (data.Number <= 0)
            Debug.LogError("Wrong Card Number!");
        else if (data.Number == 1)
            numberText.text = "A";
        else if(data.Number <= 10)
            numberText.text = data.Number.ToString();
        else if (data.Number == 11)
            numberText.text = "J";
        else if (data.Number == 12)
            numberText.text = "Q";
        else if (data.Number == 13)
            numberText.text = "K";
        else
            Debug.LogError("Wrong Card Number!");

    }
    
}

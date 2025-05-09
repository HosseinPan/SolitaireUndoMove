using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PilesController : MonoBehaviour
{
    private Pile[] piles;

    private void Awake()
    {
        piles = GetComponentsInChildren<Pile>();
    }

    private void OnEnable()
    {
        EventBus.OnInitializePiles += OnInitializePiles;
    }

    private void OnDisable()
    {
        EventBus.OnInitializePiles -= OnInitializePiles;
    }

    private void OnInitializePiles(InitializePileEventData eventData)
    {
        foreach (var pile in piles) 
        {
            switch (pile.PileName)
            {
                case PileName.WastePile:
                case PileName.FoundationPileClubs:
                case PileName.FoundationPileDiamonds:
                case PileName.FoundationPileHearts:
                case PileName.FoundationPileSpades:
                    pile.Initialize(new List<Card>());
                    break;

                case PileName.TableauPile1:
                    var cards_TableauPile1 = new List<Card>();
                    cards_TableauPile1.Add(eventData.cards[0]);
                    pile.Initialize(cards_TableauPile1);
                    break;

                case PileName.TableauPile2:
                    var cards_TableauPile2 = new List<Card>();
                    cards_TableauPile2.Add(eventData.cards[1]);
                    cards_TableauPile2.Add(eventData.cards[2]);
                    pile.Initialize(cards_TableauPile2);
                    break;

                case PileName.TableauPile3:
                    var cards_TableauPile3 = new List<Card>();
                    cards_TableauPile3.Add(eventData.cards[3]);
                    cards_TableauPile3.Add(eventData.cards[4]);
                    cards_TableauPile3.Add(eventData.cards[5]);
                    pile.Initialize(cards_TableauPile3);
                    break;

                case PileName.DrawPile:
                    var cards_DrawPile = new List<Card>();
                    for (int i = 6; i < eventData.cards.Count; i++)
                    {
                        cards_DrawPile.Add(eventData.cards[i]);
                    }
                    pile.Initialize(cards_DrawPile);
                    break;
            }
        }
    }
}

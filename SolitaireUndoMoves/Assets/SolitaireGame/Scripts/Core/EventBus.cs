using System;
using System.Collections.Generic;

public static class EventBus
{
    public static event Action OnStartGame;
    public static event Action<InitializePileEventData> OnInitializePiles;

    public static void RaiseOnStartGame()
    {
        OnStartGame?.Invoke();
    }

    public static void RaiseOnInitializePiles(InitializePileEventData eventData)
    {
        OnInitializePiles?.Invoke(eventData);
    }
}

public class InitializePileEventData
{
    public List<Card> cards;
}

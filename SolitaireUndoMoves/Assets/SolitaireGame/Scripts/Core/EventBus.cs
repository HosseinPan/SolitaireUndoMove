using System;

public static class EventBus
{
    public static event Action OnStartGame;

    public static void RaiseOnStartGame()
    {
        OnStartGame?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoMoveButton : MonoBehaviour
{
    public void OnUndoButtonClicked()
    {
        EventBus.RaiseOnUndoMove();
    }
}

using System.Xml.Serialization;
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
        
    }

    private void OnDisable()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPhase : MonoBehaviour
{
    [SerializeField] TurnPhase eventHandler;
    private void OnMouseDown()
    {
        eventHandler.NextPhase();
        Debug.Log("hello");
    }
}

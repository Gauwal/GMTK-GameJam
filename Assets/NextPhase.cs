using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextPhase : MonoBehaviour
{
    [SerializeField] TurnPhase eventHandler;
    private void OnMouseDown()
    {
        if (eventHandler.currentPhase == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        eventHandler.NextPhase();
        Debug.Log("NextPhase");
    }
}

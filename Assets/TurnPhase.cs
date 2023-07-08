using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPhase : MonoBehaviour
{
    private int currentPhase = 0;
    [SerializeField] private DragDropPath[] players;
    public void NextPhase()
    {
        currentPhase+=1;
        switch (currentPhase)
        {
            case 1:
                foreach(DragDropPath player in players) { player.SetPhase(1); }
                break;
            case 2:
                foreach (DragDropPath player in players) { player.SetPhase(2); }
                break;
            case 3:
                foreach (DragDropPath player in players) { 
                    player.SetPhase(3);
                    player.MoveAlongPath();
                
                }

                break;
            default:
                currentPhase = 0;
                Debug.Log("End");
                break;
        }
    }
}

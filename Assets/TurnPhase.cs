using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPhase : MonoBehaviour
{
    public int currentPhase = 2;
    [SerializeField] private DragDropPath[] players;
    [SerializeField] private PacManPathfinder PacMan;
    [SerializeField] private Tragetting target;

    private int PacScore;
    [SerializeField]private int EndScore;
    private bool Go;

    private UImanipulation UI;
    private void Awake()
    {
        PacScore=0;
        foreach (DragDropPath player in players)
        {
            player.SetPhase(2);
        }
        UI = GetComponent<UImanipulation>();
        UI.SetDiamondAmout(PacScore, EndScore);
    }

    public void CoinCaptured()
    {
        PacScore += 1;
        UI.SetDiamondAmout(PacScore, EndScore);
        if (PacScore >= EndScore)
        {
            UI.Showskull();
            currentPhase = 5;
            foreach (DragDropPath player in players)
            {
                player.SetPhase(5);

            }
            Debug.Log("YouLost");
        }
    }
    public void NextPhase()
    {

        currentPhase+=1;
        switch (currentPhase)
        {
            case 1:
                foreach (DragDropPath player in players) { player.SetPhase(1); }
                break;
            case 2:
                foreach (DragDropPath player in players) { player.SetPhase(2); }
                break;
            case 3:
                Go = true;
                foreach (DragDropPath player in players)
                {
                    if (!player.PathFinished())
                    {
                        Go = false;
                    }
                }
                if (Go)
                {
                    foreach (DragDropPath player in players)
                    {
                        player.SetPhase(3);
                        player.MoveAlongPath();
                        player.SetPhase(2);
                        
                    }
                    target.moveTagret();
                    PacMan.Launch();
                }
                else
                {
                    UI.ShowAvertissment();
                    Debug.Log("Must finnish all path !");
                }
                currentPhase = 2; 

                break;
            default:
                currentPhase = 5;
                Debug.Log("End");
                break;
        }

    }
}

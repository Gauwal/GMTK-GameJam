using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private TurnPhase EventHandler;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PacMan")
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
            EventHandler.CoinCaptured();
        }
    }
}

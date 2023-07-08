using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostMove : MonoBehaviour
{
    private float time_since_last_move;
    [SerializeField] public float speed;
    private int directionX;
    private int directionY;
    private int currMoveNum;




    private float cellTravelTime;

    private bool Go = false;
    // Start is called before the first frame update
    public bool Time_To_Move() { return time_since_last_move > cellTravelTime; }
    private void Awake()
    {
        cellTravelTime = 1f / speed;
        currMoveNum = 0;
        time_since_last_move = 0;
        directionX = 0;
        directionY = 0;

    }

    public void Move(Vector2Int Directionxy) 
    {
        directionX = Directionxy.x;
        directionY = Directionxy.y;
       
        time_since_last_move = 0f;


    }

    private void Update()
    {
        
        if (time_since_last_move < cellTravelTime)
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime * directionX), transform.position.y + (speed * Time.deltaTime * directionY), 0);
        }
        time_since_last_move += Time.deltaTime;
    }
}



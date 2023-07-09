using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostMove : MonoBehaviour
{
    private float time_since_last_move;
    [SerializeField] public float speed;
    public float scale;
    private int directionX;
    private int directionY;
    private Queue<Vector2> queue;
    private Animator anim;



    private float cellTravelTime;

    private bool Go = false;
    // Start is called before the first frame update
    public bool Time_To_Move() { return time_since_last_move > cellTravelTime; }
    private void Awake()
    {
        cellTravelTime = 1f / speed;
        
        time_since_last_move = 0;
        directionX = 0;
        directionY = 0;
        queue = new Queue<Vector2>();
        anim = GetComponent<Animator>();
        scale = transform.localScale.x;
    }

    public void Add_Move(Vector2Int Directionxy) 
    {
        queue.Enqueue(Directionxy);
    }

    public void Next_Move()
    {
        Vector2 direction = queue.Dequeue();
        directionX = (int)direction.x;
        directionY = (int)direction.y;
        switch (direction.x, direction.y)
        {
            case (1,0) :
                //right
                transform.localScale = new Vector3(scale, scale,0);
                anim.SetBool("Vertical", false);
                anim.SetBool("Moving", true);
                break;
            case (-1, 0):
                //left
                transform.localScale = new Vector3(-scale, scale, 0);
                anim.SetBool("Vertical", false);
                anim.SetBool("Moving", true);
                break;
            case (0, 1):
                //up
                transform.localScale = new Vector3(transform.localScale.x, scale, 0);
                anim.SetBool("Vertical", true);
                anim.SetBool("Moving", false);
                break;
            case (0, -1):
                //down
                transform.localScale = new Vector3(transform.localScale.x, -scale, 0);
                anim.SetBool("Vertical", true);
                anim.SetBool("Moving", false);
                break;
        }
        time_since_last_move = 0f;
    }

    public int Queue_Length()
    {
        return queue.Count;
    }

    

    private void Update()
    {
        
        if (time_since_last_move <= cellTravelTime)
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime * directionX), transform.position.y + (speed * Time.deltaTime * directionY), 0);
            
        }
        else
        {
            if (queue.Count > 0)
            {
                Next_Move();
                
            }
        }
        time_since_last_move += Time.deltaTime;
    }
}



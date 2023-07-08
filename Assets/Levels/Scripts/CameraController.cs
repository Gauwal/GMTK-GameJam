using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Room Camera
    [SerializeField] private float transition_time;
    private float targetPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow Camera
    [SerializeField] private Transform player;
    [SerializeField] private float lookDistance;
    [SerializeField] private float speed;
    private float lookAhead;

    private void Start()
    {
        
        targetPosX = transform.position.x;
    }

    private void Update()
    {
        //Room Camera
        //Vector3 targetPosition = new Vector3(targetPosX, transform.position.y, transform.position.z);
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, transition_time);


        //Follow Camera
        transform.position = new Vector3(player.position.x+lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (lookDistance * Mathf.Sign(player.localScale.x)),Time.deltaTime * speed);
    
    
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        targetPosX = _newRoom.position.x-3.2f;
        
    }
}

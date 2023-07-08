using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform leftRoom;
    [SerializeField] private Transform rightRoom;
    [SerializeField] private CameraController cameraController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(collision.transform.position.x < transform.position.x )
            {
                cameraController.MoveToNewRoom(rightRoom);
            }
            else
            {
                cameraController.MoveToNewRoom(leftRoom);
            }
        }
    }

}

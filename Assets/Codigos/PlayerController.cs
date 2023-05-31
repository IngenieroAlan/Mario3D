using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float gravity = 98f;
    public float moveSpeed = 5f;
    //private Animator anim;
    public float speedLimit = 50f;
    public float jumpSpeed = 20f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private Animator anim;
    private Vector3 respawnPosition;
    //public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.position;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 (x,y,z)
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            // moveDirection = transform.TransformDirection(respawnPosition);
            transform.position = respawnPosition;
            gameController.subtractScore(10);
            gameController.takeLife();
        }
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPosition = transform.position;
            gameController.addScore(100);
            Destroy(other.gameObject);
        }
        /*if (other.gameObject.CompareTag("Coin"))
        {
        }
    }*/
}

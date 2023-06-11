using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float gravity = 98f;
    public float moveSpeed = 5f;
    public float x, y;
    //private Animator anim;
    public float speedLimit = 50f;
    public float jumpSpeed = 20f;
    public float velocidadRotacion = 200.0f;
    private CharacterController controller;
    private Vector3 moveDirection;
    private Animator anim;
    private Vector3 respawnPosition;
    public GameController gameController;
    private bool banderaFinal = true;
    //public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.position;
        UnityEngine.Debug.Log("Entra: "+respawnPosition);
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 (x,y,z)

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(x, 0, y);
            moveDirection = transform.TransformDirection(moveDirection);
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            moveDirection *= moveSpeed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vacio"))
        {
            //moveDirection = transform.TransformDirection(respawnPosition);
            //transform.position = respawnPosition;
            if ((transform.position == respawnPosition)) {
                controller.Move(transform.position);
                UnityEngine.Debug.Log(true);
            }
            UnityEngine.Debug.Log("Entra: " + transform.position);
            gameController.subtractScore(10);
            gameController.takeLife();
        }
        if (other.gameObject.CompareTag("Bandera"))
        {
            if (banderaFinal) { 
                gameController.addScore(500);
            }
            respawnPosition = transform.position;
            banderaFinal = false;
            
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            gameController.addScore(100);
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bloque")){ 
            Destroy(collision.gameObject);
        }
    }
}

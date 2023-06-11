using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GoombaMovement : MonoBehaviour
{

    // Update is called once per frame
    public float speed = 5f;
    private bool isMoving;
    void Start()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            // Mueve el Goomba hacia adelante en línea recta
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pared"))
        {
            // Girar 180 grados al Goomba
            transform.Rotate(Vector3.up, 180);
        }
    }

}
/*private void OnCollisionEnter(Collision collision)
{
    // El Goomba ha colisionado con un objeto cúbico con el tag "Pared"
    if (collision.gameObject.CompareTag("Pared"))
    {
        // Girar 180 grados al Goomba
        transform.Rotate(Vector3.up, 180);
    }
}*/
/*private void OnTriggerEnte-r(Collider other)
    {
        if (other.gameObject.CompareTag("Pared"))
        {
            // Girar 180 grados al Goomba
            transform.Rotate(Vector3.up, 180);
        }
    }
*/

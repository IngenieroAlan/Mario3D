using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerController;
    public GameController gameController;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = new Vector3(0f, 1f, 0f);
            gameController.subtractScore(150);
            gameController.takeLife();
            UnityEngine.Debug.Log("Entró");
        }
    }*/
}

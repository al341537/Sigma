using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Has chocado");
        }

        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Te han disparado");
        }

        /*if (other.tag == "Bullet")
            Destroy(gameObject);*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public float shotSpeed = 1.5f;

    private Rigidbody m_rigidbody;

    void Awake()
    {
        m_rigidbody.GetComponent<Rigidbody>();
        m_rigidbody.velocity = transform.forward * shotSpeed;
    }

   /* void Start()
    {
        m_rigidbody.GetComponent<Rigidbody>();
        m_rigidbody.velocity = transform.forward * shotSpeed;
    }*/

}

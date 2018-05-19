using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementVector : MonoBehaviour {

    private Transform player;

    public float m_Speed = 6f;          //Velocidad a la que la nave va a desplazarse
    public float m_TurnSpeed = 90f;     //Velocidad a la que gira la nave, en grados
    public Transform planet;

    private string m_MovementAxisName;  //Eje sobre el que se mueve la nave
    private string m_TurnAxisName;      //Eje sobre el que gira la nave
    private Rigidbody m_RigidBody;      //Referencia al rigidbody de la nave
    private Vector3 movement;

    private Vector3 playerVect;
    private Vector3 dir;

    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        m_RigidBody = GetComponent<Rigidbody>();

        playerVect = new Vector3();
        dir = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
        playerVect = player.position - transform.position;
        dir = Vector3.ProjectOnPlane(playerVect, transform.up);
	}

    private void FixedUpdate()
    {
        Turn();
        Move();
    }

    private void Move()
    {
        movement = transform.forward.normalized * m_Speed * Time.deltaTime;

        m_RigidBody.MovePosition(m_RigidBody.position + movement);
    }

    private void Turn()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir, Vector3.up), Time.deltaTime * m_TurnSpeed);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, playerVect);
        Debug.DrawRay(transform.position, dir);
    }
}

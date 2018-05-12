using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float m_Speed = 6f;          //Velocidad a la que la nave va a desplazarse
    public float m_TurnSpeed = 90f;     //Velocidad a la que gira la nave, en grados
    public Transform planet;

    private string m_MovementAxisName;  //Eje sobre el que se mueve la nave
    private string m_TurnAxisName;      //Eje sobre el que gira la nave
    private Rigidbody m_RigidBody;      //Referencia al rigidbody de la nave
    private float m_MovementInputValue; //Valor actual de movimiento introducido por el usuario
    private float m_TurnInputValue;     //Valor actual de giro introducido por el usuario
    private Vector3 movement;




    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_RigidBody.isKinematic = false; //Mientras la nave sea controlable, se le aplicarán fuerzas

        //Reseteamos los valores introducidos por el usuario para que la nave no empieze moviendose

        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;

    }

    private void OnDisable()
    {
        m_RigidBody.isKinematic = true;

    }

    private void Start()
    {
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";


    }

    private void Update()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

        //Vector3 t = new Vector3(m_MovementInputValue, 0, m_TurnInputValue);


    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        //CameraRotation();
    }

    private void Move()
    {
        //Creamos un vector en la direccion a la que la nave apunta con una magnitud a partir de la introducida, la velocidad de la nave y el tiempo entre frames (DeltaTime)
        movement = transform.forward.normalized * m_MovementInputValue * m_Speed * Time.deltaTime; 

        //Aplicar el movimiento a la posición del rigid body
        m_RigidBody.MovePosition(m_RigidBody.position + movement);
    }

    private void Turn()
    {

        //Determinamos el numero de grados para girar basado en el input, la velocidad y el tiempo entre frames
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        //Rotamos en el eje Y, usando cuaterniones

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        //Aplicamos la rotacion al rigid body
        m_RigidBody.MoveRotation(m_RigidBody.rotation * turnRotation);

    }

    private void CameraRotation()
    {
        /*if (m_MovementInputValue > 0)
        {
            Camera.main.transform.RotateAround(Vector3.zero, transform.right, RotationPerSecond() * Time.deltaTime);

        }
        else if (m_MovementInputValue < 0)
        {
            Camera.main.transform.RotateAround(Vector3.zero, -transform.right, RotationPerSecond() * Time.deltaTime);

        }*/

        Camera.main.transform.position = new Vector3(transform.position.x * 10, transform.position.y * 10, transform.position.z * 10);
        //Camera.main.transform.forward = transform.position - Camera.main.transform.position;
        //print(Camera.main.transform.forward);


        Camera.main.transform.forward = new Vector3( (transform.position.x - Camera.main.transform.position.x), (transform.position.y - Camera.main.transform.position.y), (transform.position.z - Camera.main.transform.position.z));


    }

    private float RotationPerSecond()
    {
        float radius = planet.transform.localScale.y / 2;
        float circumference = (2 * Mathf.PI) * radius;
        print(movement);
        float secondsToCirclePlanet = circumference / (movement * m_Speed).magnitude;
        float degreesPerSecond = 360 / secondsToCirclePlanet;
        return degreesPerSecond;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target; //Posición que la cámara seguirá durante la ejecución del juego
    public float smoothing = 5f;

    private Vector3 offset;

   

	void Start ()
    {
        //Calculamos el offset inicial
        offset = transform.position - target.position;
      
	}

    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset; //Crea una posición a la que apunta la cámara basado en el offset del target

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
	
}

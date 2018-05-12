using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailManager : MonoBehaviour {

    float timer;
    TrailRenderer trail;

	void Awake () {
        trail = gameObject.GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        while (Input.GetKeyDown("w"))
        {
            trail.enabled = true;
            timer = 0;
        }

        timer += Time.deltaTime;
        if(timer > 0.3)
        {
            trail.enabled = false;
        }
	}
}

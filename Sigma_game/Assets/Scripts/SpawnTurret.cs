using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurret : MonoBehaviour {

    public GameObject turretPrefab;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateTurret", 0f, 5f);
	}

    void CreateTurret()
    {
        Vector3 position = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        Instantiate(turretPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

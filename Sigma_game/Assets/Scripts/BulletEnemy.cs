using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

    public float speed = 70f;
    public float lifeTime = 1f;

    private Transform target;
    private Vector3 dir;
    private float lifeCountdown;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        dir = target.position - transform.position;
        lifeCountdown = lifeTime;
    }

    private void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        float distanceThisFrame = speed * Time.deltaTime;
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        if (lifeCountdown <= 0)
            Destroy(gameObject);

        lifeCountdown -= Time.deltaTime;

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            //Destroy(other.gameObject);
        }
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}

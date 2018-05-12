using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour {

    [Header("Atributes")]

    public float range = 15f;
    public float turnSpeed = 5f;
    public float fireRate = 1f;
    public float bulletSpeed = 30f;

    [Header("Unity Setup Fields")]

    public Transform partToRotate;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform target;
    private string playerTag = "Player";

    private float fireCountdown = 1f;

    public NavMeshSurface surface;


    // Use this for initialization
    void Start () {
        //InvokeRepeating("FindTarget", 0f, 0.5f);
        GameObject nav = GameObject.FindGameObjectWithTag("NavMeshSurface");
        surface = nav.GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }

    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player == null)
            return;

        if(Vector3.Distance(transform.position, player.transform.position) <= range)
        {
            target = player.transform;
        }

        else
        {
            target = null;
            fireCountdown = 1f;
        }

    }
	
	// Update is called once per frame
	void Update () {
		if(target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //Quaternion.LookRotation(dir) == partToRotate.rotation

        if (fireCountdown <= 0f)
        {
            Fire();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
	}

    void Fire()
    {
        var bullet = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        bullet.SetActive(true);

        Vector3 dir = target.position - bullet.transform.position;
   

        bullet.GetComponent<Rigidbody>().velocity = dir.normalized * bulletSpeed;

        Destroy(bullet, 0.5f);

        /*GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletEnemy bullet = bulletGO.GetComponent<BulletEnemy>();

        if (bullet != null)
            bullet.Seek(target);*/
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public Transform GetTarget()
    {
        return target;
    }

    
}

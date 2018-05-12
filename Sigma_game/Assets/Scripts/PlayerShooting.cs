using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed = 30f;
    public float timeBetweenBullets = 0.3f;

    float timer;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Fire();
        }
    }

    void Fire()
    {
        timer = 0f;

        var bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.SetActive(true);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;

        Destroy(bullet, 2.0f);
    }
}

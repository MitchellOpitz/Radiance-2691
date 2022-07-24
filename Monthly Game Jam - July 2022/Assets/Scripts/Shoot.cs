using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shotInterval = 0.1f;
    public float bulletSpeed = 20f;

    private float timeSenseLastShot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            timeSenseLastShot += Time.deltaTime;
            if (timeSenseLastShot >= shotInterval)
                ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        timeSenseLastShot = 0f;
    }
}

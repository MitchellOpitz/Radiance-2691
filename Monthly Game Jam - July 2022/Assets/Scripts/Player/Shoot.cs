using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    // Public variables
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shotInterval = 0.1f;
    public float bulletSpeed = 20f;
    public AudioSource audioManager;

    // Private variables
    private float timeSenseLastShot = 0f;

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
        if(gameObject.tag == "Player")
        {
            audioManager.Play();
        }
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        timeSenseLastShot = 0f;
    }
}

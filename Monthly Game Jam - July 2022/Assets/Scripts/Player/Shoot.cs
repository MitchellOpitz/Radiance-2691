using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    // Public variables
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public AudioSource audioManager;
    private GameManager gameManager;

    private float shotInterval = 0.5f;

    // Private variables
    private float timeSenseLastShot = 0f;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        shotInterval = 0.5f - ((0.5f * 0.1f) * gameManager.GetRateOfFireRank());
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

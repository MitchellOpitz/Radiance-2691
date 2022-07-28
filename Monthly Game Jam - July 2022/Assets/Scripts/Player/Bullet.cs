using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Public variables
    public int damage = 5;
    public BoxCollider2D player;
    // public GameObject hitEffect;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), player);
    }

    // Occurs when bullet exits Field of Play game object.
    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
            Physics2D.IgnoreCollision(
                collision.gameObject.GetComponent<CircleCollider2D>(),
                GetComponent<CircleCollider2D>()
                );

        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);  // Cleans up hit effects game objects in the hierarchy.

        if (collision.transform.tag == "Enemy")
        {
            var totalDamage = damage + (damage * gameManager.GetDamageMultiplierRank());
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(totalDamage);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Public variables
    public int damage = 5;
    // public GameObject hitEffect;

    // Occurs when bullet exits Field of Play game object.
    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);  // Cleans up hit effects game objects in the hierarchy.

        if(collision.transform.tag == "Enemy")
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Public variables
    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    // Class variables
    Transform player;
    Vector2 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player)
        {
            moveDirection = (player.position - transform.position).normalized;

            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }

    void FixedUpdate()
    {
        if (player)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
}

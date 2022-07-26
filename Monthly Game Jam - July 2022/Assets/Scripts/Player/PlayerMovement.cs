using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public variables
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public Camera cam;
    public float maxX = 5f;
    public float maxY = 5f;

    // Class variables
    Vector2 playerMovement;
    Vector2 mousePosition;

    void Update()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        // Clamps player's position to Field of Play
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -maxX, maxX),
            Mathf.Clamp(transform.position.y, -maxY, maxY)
            );

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerMovement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}

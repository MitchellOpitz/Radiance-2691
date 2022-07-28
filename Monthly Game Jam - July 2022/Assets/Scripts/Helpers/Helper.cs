using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    // Public variables
    public float rotationSpeed = 5f;
    public float radius = 1f;
    public Camera cam;
    public Rigidbody2D rb;
    public GameObject particles;

    public GameObject player;
    public Vector2 centerPoint;
    public float angle;

    private Color color;

    // Class variables
    Vector2 mousePosition;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = player.transform.position;
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        centerPoint = player.transform.position;
        angle += rotationSpeed * Time.deltaTime;
        if (angle > 360)
            angle -= 360;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = centerPoint + offset;

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        moveDirection = (centerPoint + offset - mousePosition).normalized;

        float rotationAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = rotationAngle;
    }

    public void DestroyHelper()
    {
        GameObject particleEffects = Instantiate(particles, transform.position, transform.rotation);
        ParticleSystem.MainModule main = particleEffects.GetComponent<ParticleSystem>().main;
        main.startColor = color;
        Destroy(gameObject);
    }
}

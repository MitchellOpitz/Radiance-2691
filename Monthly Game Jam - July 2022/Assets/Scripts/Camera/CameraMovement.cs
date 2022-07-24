using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // Public variables
    public Transform player;
    public float maxX = 5f;
    public float maxY = 5f;

    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, -maxX, maxX),
            Mathf.Clamp(player.position.y, -maxY, maxY),
            transform.position.z);
    }
}

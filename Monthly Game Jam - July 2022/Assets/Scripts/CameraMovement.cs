using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float maxX = 5f;
    public float maxY = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, -maxX, maxX),
            Mathf.Clamp(target.position.y, -maxY, maxY),
            transform.position.z);
    }
}

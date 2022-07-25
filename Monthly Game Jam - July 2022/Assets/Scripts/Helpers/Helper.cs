using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{

    public float rotationSpeed = 5f;
    public float radius = 1f;

    public GameObject player;
    public Vector2 centerPoint;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        centerPoint = player.transform.position;
        angle += rotationSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = centerPoint + offset;
    }
}

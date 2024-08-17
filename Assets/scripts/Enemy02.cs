using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour
{
    public float minX = 24.39f;
    public float maxX = 27.12f;
    public float speed = 0.8f;

    // Update is called once per frame
    void Update()
    {
        // Move the enemy back and forth between minX and maxX along the x-axis
        float xPosition = Mathf.PingPong(Time.time * speed, maxX - minX) + minX;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}

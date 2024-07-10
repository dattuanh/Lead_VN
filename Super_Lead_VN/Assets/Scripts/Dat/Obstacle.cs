using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;
    public float baseSpeed = 1f;


    private void Start()
    {
        // subtract 1 to make the obs completely off the screen
        // and then we will destroy it
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        SpeedManager.UpdateSpeed();
        float speed = baseSpeed + SpeedManager.GetCurrentSpeed();
        transform.position += Vector3.left * speed * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingPoint : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Game Finished!");
            //Time.timeScale = 0;

            SceneController.instance.NextLevel();
        }
    }
}

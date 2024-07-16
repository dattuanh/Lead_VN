using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    bool isFacingRight = false;
    float jumpPower = 9f;
    bool isGrounded = false;
    Rigidbody2D rb;
    //AudioSource audioSource;
    AudioLead audioManager;
    Health health;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioLead>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            TiltCharacter(true);
            audioManager.PlaySFX(audioManager.jump);
        }
    }

    private void FixedUpdate()
    {
    }

    // Method called when the player collides with another object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
            TiltCharacter(false);
        }
        else if (collision.CompareTag("Enemy"))
        {
            health.TakeDamage(1);
            //audioManager.PlaySFX(audioManager.motorcrash);
        }
    }

    void TiltCharacter(bool isJumping)
    {
        if (isJumping && isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        if (isJumping && !isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


}

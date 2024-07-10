using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    bool isFacingRight = false;
    float jumpPower = 7f;
    bool isGrounded = false;
    Rigidbody2D rb;
    //AudioSource audioSource;
    AudioManager audioManager;
    Health health;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        TiltCharacter(false);
        if (collision.CompareTag("Enemy"))
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
        else if (isJumping && !isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


}

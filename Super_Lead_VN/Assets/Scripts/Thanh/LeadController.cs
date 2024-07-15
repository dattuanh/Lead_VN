using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadController : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 7f;
    bool isFacingRight = false;
    float jumpPower = 7f;
    bool isGrounded = false;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        FlipSprite();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            TiltCharacter(true);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isGrounded && (isFacingRight && horizontalInput > 0f || !isFacingRight && horizontalInput < 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        TiltCharacter(false);
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

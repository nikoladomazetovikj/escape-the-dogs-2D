using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float runSpeed = 0.5f;
    public float jumpForce = 2f;
    public float jumpDuration = 0.5f; // Duration of the jump

    private float jumpTime; // Time elapsed since the jump started
    private bool isJumping; // Flag to track if the player is currently jumping

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetKeyDown(KeyCode.UpArrow);

        // Run
        if (horizontalInput != 0)
        {
            animator.SetBool("Run", true);
            // Move the object horizontally
            rb.velocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
        }
        else
        {
            animator.SetBool("Run", false);
            // Stop the horizontal movement
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        // Jump
        if (jumpInput && !isJumping)
        {
            animator.SetTrigger("Jump");
            isJumping = true;
            jumpTime = 0f;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Check if the jump duration has elapsed
        if (isJumping && jumpTime >= jumpDuration)
        {
            isJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Cancel vertical velocity
        }

        jumpTime += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameController.instance.CollectCoin();
            Destroy(collision.gameObject);
        }
    }
}

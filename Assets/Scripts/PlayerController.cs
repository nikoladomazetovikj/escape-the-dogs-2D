using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float runSpeed = 0.5f;
    public float jumpForce = 2f;
    public float maxJumpForce = 2.8f; // Maximum jump force limit

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
        if (horizontalInput > 0)
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
        if (jumpInput)
        {
            animator.SetTrigger("Jump");
            // Apply upward force for jumping, limited to maxJumpForce
            rb.AddForce(new Vector2(0f, Mathf.Min(jumpForce, maxJumpForce)), ForceMode2D.Impulse);
        }
    }
}

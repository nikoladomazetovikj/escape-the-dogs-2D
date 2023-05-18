using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        }
        else
        {
            animator.SetBool("Run", false);
        }

        // Jump
        if (jumpInput)
        {
            animator.SetTrigger("Jump");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjectController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float backgroundWidth;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, 0);

        // Get the width of the background sprite or collider
        backgroundWidth = GetBackgroundWidth();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gameOver)
        {
            rb2d.velocity = Vector2.zero;
        }

        // Check if the background has moved offscreen
        if (transform.position.x < -backgroundWidth)
        {
            // Reset the background position to repeat the scene
            RepositionBackground();
        }
    }

    float GetBackgroundWidth()
    {
        // Get the width of the background sprite renderer or collider
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            return spriteRenderer.bounds.size.x;
        }

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            return collider.bounds.size.x;
        }

        return 0f;
    }

    void RepositionBackground()
    {
        // Calculate the new position for the background
        float backgroundWidth = GetBackgroundWidth();
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = new Vector2(currentPosition.x + backgroundWidth, currentPosition.y);

        // Move the background to the new position
        transform.position = newPosition;
    }

    
}

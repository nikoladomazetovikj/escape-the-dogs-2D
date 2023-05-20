using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjectController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool isManMoving;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.zero;
        isManMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            // Check if the player object is moving
            bool isMoving = GetPlayerMoving();
            SetManMoving(isMoving);
        }
    }

    void SetManMoving(bool isMoving)
    {
        isManMoving = isMoving;
        if (isManMoving)
        {
            rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    bool GetPlayerMoving()
    {
        GameObject playerObject = GameObject.FindWithTag("Man");
        if (playerObject != null)
        {
            Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
            return playerRigidbody.velocity.magnitude > 0f;
        }
        return false;
    }
}

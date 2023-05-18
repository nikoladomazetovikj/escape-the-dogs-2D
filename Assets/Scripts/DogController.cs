using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Camera mainCamera;
    private bool isOffScreen;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Move to the left
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);

        // Check if the object is outside the camera's screen
        CheckIfOffScreen();
        if (isOffScreen)
        {
            Destroy(gameObject);
        }
    }

    private void CheckIfOffScreen()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        isOffScreen = (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the dog collided with the Man object
        if (collision.CompareTag("Man"))
        {
            // Destroy the Man object
            Destroy(collision.gameObject);
        }
    }
}

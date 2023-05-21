using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerController : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 3f;
    public float spawnRange = 5f;
    public float spawnYOffset = 0.5f; // Offset along the y-axis for spawning coins

    private GameController gameController; // Reference to the GameController script

    private void Start()
    {
        gameController = GameController.instance; // Get the GameController instance
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (!gameController.gameOver) // Check if the game is not over
            {
                // Generate a random x-coordinate within the spawn range
                float spawnX = Random.Range(transform.position.x - spawnRange, transform.position.x + spawnRange);

                // Calculate the spawn position
                Vector3 spawnPosition = new Vector3(spawnX, transform.position.y + spawnYOffset, transform.position.z);

                // Instantiate the coin prefab at the spawn position
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
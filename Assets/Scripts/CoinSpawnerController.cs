using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerController : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 3f;
    public float spawnRange = 5f;

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
                // Generate a random position within the spawn range
                Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, 0f);

                // Instantiate the coin prefab at the random position
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

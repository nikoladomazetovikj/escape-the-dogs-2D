using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteDogSpawnerController : MonoBehaviour
{
    public GameObject whiteDogPrefab;
    public float spawnInterval = 7.5f;
    public bool rotatePrefab = true; // Flag to enable rotation

    private void Start()
    {
        StartCoroutine(SpawnWhiteDogs());
    }

    private IEnumerator SpawnWhiteDogs()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            
            if (GameController.instance.gameOver)
                yield break;

            // Instantiate the white dog prefab
            GameObject whiteDog = Instantiate(whiteDogPrefab, transform.position, Quaternion.identity);

            // Rotate the white dog prefab if enabled
            if (rotatePrefab)
            {
                whiteDog.transform.Rotate(0f, 180f, 0f); // Rotate by 180 degrees along the Y-axis
            }
        }
    }
}

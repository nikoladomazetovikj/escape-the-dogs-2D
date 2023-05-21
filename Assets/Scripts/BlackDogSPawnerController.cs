using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackDogSPawnerController : MonoBehaviour
{
    public GameObject blackDogPrefab;
    public float spawnInterval = 7f;

    private void Start()
    {
        StartCoroutine(SpawnBlackDogs());
    }

    private IEnumerator SpawnBlackDogs()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (GameController.instance.gameOver)
                yield break;
            Instantiate(blackDogPrefab, transform.position, Quaternion.identity);
        }
    }
}

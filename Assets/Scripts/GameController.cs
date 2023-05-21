using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    public GameObject gameOverText;

    public bool gameOver = false;

    public float scrollSpeed = -1f;

    private int score = 0;
    
    private int coinsCount = 0;

    public Text scoreText;

    public Text coinsText;

    public GameObject restartButton;

    public GameObject exitButton;
    
    public GameObject youWinText;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (score >= 100 && !gameOver)
        {
            GameWin();
        }
    }


    public void ManScored(int scoreValue)
	{
    	if (gameOver)
    	{
       		 return;
    	}

    	score += scoreValue;
        scoreText.text = "SCORE: " + score.ToString();
	}
    
    
    public void CollectCoin()
    {
        if (gameOver)
        {
            return;
        }

        coinsCount++;
        coinsText.text = "COINS: " + coinsCount.ToString();
    }


    public void ManDied()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
        scoreText.enabled = false;
        coinsText.enabled = false;
        
        gameOver = true;
    }
    
    private void GameWin()
    {
        youWinText.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
        scoreText.enabled = false;
        coinsText.enabled = false;
        gameOverText.SetActive(false);
        gameOver = true;
        
        DestroyObjectsWithTag("Man");
        DestroyObjectsWithTag("Coin");
        DestroyObjectsWithTag("WhiteDog");
        DestroyObjectsWithTag("BlackDog");
    }
    
    
    private void DestroyObjectsWithTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
    
}

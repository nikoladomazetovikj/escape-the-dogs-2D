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

    public float scrollSpeed = -1.5f;

    private int score = 0;

    public Text scoreText;
    
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


    public void ManDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}

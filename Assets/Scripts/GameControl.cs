using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public Text scoreText1;
    public Text victoryText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private int score = 0;
    private int score1 = 0;
    private int deadBirds = 0;

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
        if (gameOver && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        ++score;
        scoreText.text = "Player 1 Score: " + score.ToString();
    }

    public void BirdScored1()
    {
        if (gameOver)
        {
            return;
        }
        ++score1;
        scoreText1.text = "Player 2 Score: " + score1.ToString();
    }

    public void BirdDied()
    {
        ++deadBirds;

        if (deadBirds >= 2)
        {
            if (score > score1)
            {
                victoryText.text = "Player 1 Wins!";
            }
            else if (score1 > score)
            {
                victoryText.text = "Player 2 Wins!";
            }
            else
            {
                victoryText.text = "Tie!";
            }

            gameOverText.SetActive(true);
            gameOver = true;
        }
    }
}

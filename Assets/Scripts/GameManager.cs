using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float countDown = 5;
    public float gameTime;
    public bool gameOver, gameStarted, gamePaused, safeLockQuit;
    public ScoreKeeper opponentScore, playerScore;
    public Transform opponentTransform, playerTransform;
    public TextMeshPro timeText, countDownText, statusText;
    public GameObject time, opponent;
    public SpriteRenderer playerSprite;

    void Start()
    {
        playerSprite.color = new Color(ColorScript.r / 255, ColorScript.g / 255, ColorScript.b / 255);
    }
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetAxisRaw("Cancel") > 0)
                SceneManager.LoadScene(0);
            countDown -= Time.deltaTime;
            if (countDown > 1)
                countDownText.text = countDown.ToString("0");

            else if (countDown <= 1 && countDown > 0)
                countDownText.text = "GO";

            else
            {
                gamePaused = false;
                gameStarted = true;
                countDownText.text = "";
                time.SetActive(true);
            }
        }
        else
        {
            if (!gameOver && !gamePaused && Input.GetAxisRaw("Cancel") > 0)
                StartCoroutine(PauseGame());
            else if (Input.GetAxisRaw("Submit") > 0 & gamePaused)
            {
                gamePaused = false;
                statusText.text = "";
                gameStarted = false;

            }
            else if (gameOver && Input.GetAxisRaw("Submit") > 0)
            {
                if (MenuScript.hardMode)
                    SceneManager.LoadScene(3);
                else
                    SceneManager.LoadScene(2);

            }
            else if (gameOver && Input.GetAxisRaw("Cancel") > 0)
                SceneManager.LoadScene(0);
            else if (gameTime > 0 && !gamePaused)
            {
                gameTime -= Time.deltaTime;
                timeText.text = gameTime.ToString("00");
            }
            else if (gamePaused && Input.GetAxisRaw("Cancel") > 0 && !safeLockQuit)
                SceneManager.LoadScene(0);
            else if (!gameOver && !gamePaused)
            {
                GameOver();
                gameOver = true;
            }
        }
    }

    void GameOver()
    {
        if (playerScore.score > opponentScore.score)
            WinGame();

        else if (playerScore.score < opponentScore.score)
            LoseGame();
        else //when scores are equal whoever that is closer to the goal is the winner.
            if ((playerTransform.position.x < opponentTransform.position.x && playerScore.score % 2 != 0)
            || (playerTransform.position.x > opponentTransform.position.x && playerScore.score % 2 == 0))
            WinGame();
        else
            LoseGame();
    }

    void WinGame()
    {
        statusText.text = "You Win!";
        Destroy(opponent);
    }

    void LoseGame()
    {
        statusText.text = "You Lose!";
        playerSprite.color = new Color(0, 0, 0, 1);
    }

    IEnumerator PauseGame()
    {
        if (Input.GetAxisRaw("Cancel") > 0 && gameStarted && !gameOver)
        {
            safeLockQuit = true;
            gamePaused = true;
            statusText.text = "Paused";
            countDown = 5;
            yield return new WaitForSeconds(1f);
            safeLockQuit = false;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    public float opponentSpeed, speedModifier;
    private ScoreKeeper scoreKeeper;
    public GameManager gameMode;

    void Start()
    {
        scoreKeeper = GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        if (gameMode.gameStarted && !gameMode.gameOver && !gameMode.gamePaused)
        {
            float adjustedSpeed = opponentSpeed * speedModifier;
            transform.position += (Vector3.right * adjustedSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Start" || collision.tag == "End")
        {
            speedModifier = Random.Range(0.5f, 2);
            opponentSpeed *= -1.0f;    
            scoreKeeper.IncrementScore();        
        }
    }
}

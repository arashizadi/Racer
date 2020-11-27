using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMovement : MonoBehaviour
{
    public GameManager gameMode;
    public float playerSpeed;
    float xMove;
    ScoreKeeper scoreKeeper;
    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        scoreKeeper = GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        if (gameMode.gameStarted && !gameMode.gameOver && !gameMode.gamePaused)
            xMove = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        else
            transform.position = new Vector3(transform.position.x, transform.position.y);
    }
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(xMove, 0);
        rigidBody.AddForce(movement, ForceMode2D.Force);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Start" && scoreKeeper.score % 2 != 0)
            || (collision.tag == "End" && scoreKeeper.score % 2 == 0))
            scoreKeeper.IncrementScore();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Arash
{
    public class PlayerMovement : MonoBehaviour
    {
        public float playerSpeed;
        ScoreKeeper scoreKeeper;
        public GameManager gameMode;

        void Start()
        {
            scoreKeeper = GetComponent<ScoreKeeper>();
        }

        void Update()
        {
            ControlMovement();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((collision.tag == "Start" && scoreKeeper.score % 2 != 0)
                || (collision.tag == "End" && scoreKeeper.score % 2 == 0))
                scoreKeeper.IncrementScore();
        }

        private void ControlMovement()
        {
            if (gameMode.gameStarted && !gameMode.gameOver && !gameMode.gamePaused)
            {
                if (Input.GetAxis("Horizontal") > 0)
                    transform.position += (Vector3.right * playerSpeed * Time.deltaTime);
                else if (Input.GetAxis("Horizontal") < 0)
                    transform.position += (Vector3.left * playerSpeed * Time.deltaTime);
            }
            else
                transform.position = new Vector3(transform.position.x, transform.position.y);
        }
    }

}

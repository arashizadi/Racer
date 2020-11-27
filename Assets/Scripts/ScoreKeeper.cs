using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro scoreText;
    public GameManager gameMode;
    public int score;
    public void IncrementScore()
    {
        if (!gameMode.gameOver)
        {
            score++;
            scoreText.text = score.ToString("00");
        }
    }
}


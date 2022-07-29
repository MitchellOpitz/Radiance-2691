using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Public variables
    public Text scoreText;
    public Text gameOverText;
    public GameObject gameOverPanel;

    // Private variables
    private int totalScore;

    void Awake()
    {
        totalScore = 0;
    }

    public void UpdateScore(int value)
    {
        totalScore += value;
        scoreText.text = totalScore.ToString("0000000");
    }

    public void GameOverScore()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = totalScore.ToString("0000000");
    }
}

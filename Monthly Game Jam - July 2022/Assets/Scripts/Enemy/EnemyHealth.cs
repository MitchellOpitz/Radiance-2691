using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    // Public variables
    public int maxHealth = 100;
    public int xpAmount = 20;

    // Private variables
    private int healthRemaining;
    private LevelSystem playerLevel;
    private AudioSource audioManager;
    private Score scoreText;
    private GameManager gameManager;
    private int scoreAmount;

    void Awake()
    {
        healthRemaining = maxHealth;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
        audioManager = GameObject.Find("Sound Effects").GetComponent<AudioSource>();
        scoreText = GameObject.Find("Score Text").GetComponent<Score>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void TakeDamage(int damageAmount)
    {
        healthRemaining -= damageAmount;

        if (healthRemaining <= 0)
        {
            scoreAmount = 10 * (gameManager.GetScoreMultiplierRank() + 1);
            scoreText.UpdateScore(scoreAmount);
            audioManager.Play();
            Destroy(gameObject);
            playerLevel.AddXP(xpAmount);
        }
    }
}

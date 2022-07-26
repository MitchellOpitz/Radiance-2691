using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    // Public variables
    public int maxHealth = 100;
    public int xpAmount = 20;
    public int scoreAmount = 10;

    // Private variables
    private int healthRemaining;
    private LevelSystem playerLevel;
    private AudioSource audioManager;
    private Score scoreText;

    void Awake()
    {
        healthRemaining = maxHealth;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
        audioManager = GameObject.Find("Sound Effects").GetComponent<AudioSource>();
        scoreText = GameObject.Find("Score Text").GetComponent<Score>();
    }

    public void TakeDamage(int damageAmount)
    {
        healthRemaining -= damageAmount;

        if (healthRemaining <= 0)
        {
            scoreText.UpdateScore(scoreAmount);
            audioManager.Play();
            Destroy(gameObject);
            playerLevel.AddXP(xpAmount);
        }
    }
}

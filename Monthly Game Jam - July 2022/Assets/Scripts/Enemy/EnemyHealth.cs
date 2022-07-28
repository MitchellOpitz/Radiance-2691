using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    // Public variables
    public int maxHealth = 20;
    public int xpAmount = 20;
    public GameObject particles;

    // Private variables
    private int healthRemaining;
    private LevelSystem playerLevel;
    private AudioSource audioManager;
    private Score scoreText;
    private GameManager gameManager;
    private int scoreAmount;

    private Color color;

    void Awake()
    {
        healthRemaining = maxHealth;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
        audioManager = GameObject.Find("Sound Effects").GetComponent<AudioSource>();
        scoreText = GameObject.Find("Score Text").GetComponent<Score>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        maxHealth = 20 + (5 * gameManager.GetLevel());
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    public void TakeDamage(int damageAmount)
    {
        healthRemaining -= damageAmount;

        if (healthRemaining <= 0)
        {
            GameObject particleEffects = Instantiate(particles, transform.position, transform.rotation);
            ParticleSystem.MainModule main = particleEffects.GetComponent<ParticleSystem>().main;
            main.startColor = color;
            scoreAmount = 10 * (gameManager.GetScoreMultiplierRank() + 1);
            scoreText.UpdateScore(scoreAmount);
            audioManager.Play();
            Destroy(gameObject);
            playerLevel.AddXP(xpAmount);
        }
    }
}

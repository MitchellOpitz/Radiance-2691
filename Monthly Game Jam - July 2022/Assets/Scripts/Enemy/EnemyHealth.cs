using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    // Public variables
    public int maxHealth = 20;
    public int xpAmount = 10;
    public GameObject particles;
    public AudioClip damageSound;

    // Private variables
    private int healthRemaining;
    private LevelSystem playerLevel;
    private AudioSource audioManager;
    private Score scoreText;
    private GameManager gameManager;
    private int scoreAmount;
    private int bossScoreScale = 1;

    private int level;

    private Color color;

    void Awake()
    {
        healthRemaining = maxHealth;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
        audioManager = GameObject.Find("Sound Effects").GetComponent<AudioSource>();
        scoreText = GameObject.Find("Score Text").GetComponent<Score>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        level = gameManager.GetLevel();
        maxHealth = 20 + (5 * level);
        color = gameObject.GetComponent<SpriteRenderer>().color;

        ParticleSystem.MainModule main = particles.GetComponent<ParticleSystem>().main;
        main.startColor = color;
        main.duration = 1;
        ParticleSystem.ShapeModule shapes = particles.GetComponent<ParticleSystem>().shape;
        shapes.radius = 1;

        BossCheck();
    }

    public void TakeDamage(int damageAmount)
    {
        healthRemaining -= damageAmount;

        if (healthRemaining <= 0)
        {
            GameObject particleEffects = Instantiate(particles, transform.position, transform.rotation);
            scoreAmount = 10 * (gameManager.GetScoreMultiplierRank() + 1) * bossScoreScale;
            scoreText.UpdateScore(scoreAmount);
            audioManager.clip = damageSound;
            audioManager.Play();
            Destroy(gameObject);
            playerLevel.AddXP(xpAmount);
        }
    }

    void BossCheck()
    {
        int random = Random.Range(1, 101);
        if(random < level)
        {
            maxHealth *= 3;
            xpAmount *= 2;
            bossScoreScale = 3;
            gameObject.transform.localScale = new Vector3(2, 2, 1);
        }
    }
}

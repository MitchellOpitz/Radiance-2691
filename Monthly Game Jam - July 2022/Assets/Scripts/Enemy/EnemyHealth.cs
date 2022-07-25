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

    void Awake()
    {
        healthRemaining = maxHealth;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
        audioManager = GameObject.Find("Sound Effects").GetComponent<AudioSource>();
    }

    public void TakeDamage(int damageAmount)
    {
        healthRemaining -= damageAmount;

        if (healthRemaining <= 0)
        {
            audioManager.Play();
            Destroy(gameObject);
            playerLevel.AddXP(xpAmount);
        }
    }
}

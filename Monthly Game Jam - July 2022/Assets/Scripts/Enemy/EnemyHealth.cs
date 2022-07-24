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

    void Awake()
    {
        healthRemaining = maxHealth;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
    }

    public void TakeDamage(int damageAmount)
    {
        healthRemaining -= damageAmount;

        if (healthRemaining <= 0)
        {
            Destroy(gameObject);
            playerLevel.AddXP(xpAmount);
        }
    }
}

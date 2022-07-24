using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int xpAmount = 20;
    public LevelSystem playerLevel;

    private int healthRemaining;
    // Start is called before the first frame update
    void Start()
    {
        healthRemaining = maxHealth;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        healthRemaining -= damageAmount;
        //Debug.Log("Damage amount: " + damageAmount);
        //Debug.Log("Enemy health remaining: " + healthRemaining);

        if (healthRemaining <= 0)
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
        playerLevel.AddXP(xpAmount);
    }
}

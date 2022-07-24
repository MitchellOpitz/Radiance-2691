using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{

    private int level;
    private int currentXP;
    private int xpToNextLevel;

    public LevelSystem()
    {
        level = 0;
        currentXP = 0;
        xpToNextLevel = 100;
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        //Debug.Log("Current XP: " + currentXP);

        if (currentXP >= xpToNextLevel)
        {
            levelUp();
        }
    }

    private void levelUp()
    {
        level++;
        //Debug.Log("Level " + level + "!");
        currentXP -= xpToNextLevel;
        xpToNextLevel = (int)(xpToNextLevel * 1.1);
        //Debug.Log("XP to next level: " + xpToNextLevel);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

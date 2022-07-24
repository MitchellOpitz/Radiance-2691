using System.Collections;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    // Private variables
    private int level;
    private int currentXP;
    private int xpToNextLevel;

    public LevelSystem()
    {
        level = 1;
        currentXP = 0;
        xpToNextLevel = 100;
    }

    public void AddXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= xpToNextLevel)
        {
            // Level up
            level++;
            currentXP -= xpToNextLevel;
            xpToNextLevel = (int)(xpToNextLevel * 1.1);
        }
    }
}

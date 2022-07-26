using System.Collections;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{

    // Public variables
    public UIManager UI;
    public EnemySpawner spawner;
    public GameManager gameManager;

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
            UI.UpdateLevelText("" + level);
            spawner.IncreaseSpawnRate();
            gameManager.AddShopPoint();
        }

        UI.UpdateXPBar((float)currentXP / (float)xpToNextLevel);
    }
}

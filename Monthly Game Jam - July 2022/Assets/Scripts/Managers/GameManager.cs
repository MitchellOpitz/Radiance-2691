using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Private variables
    private int shopPoints;
    private int totalHelpers;
    private int rateOfFireRank;
    private int scoreMultiplierRank;

    private void Awake()
    {
        shopPoints = 8;
        totalHelpers = 0;
        rateOfFireRank = 0;
    }

    public void AddShopPoint()
    {
        shopPoints++;
        // Debug.Log("Total Shop Points: " + shopPoints);
    }

    public void SpendPoint()
    {
        shopPoints--;
    }

    public int GetShopPoints()
    {
        return shopPoints;
    }

    public int GetTotalHelpers()
    {
        return totalHelpers;
    }

    public void AddHelper()
    {
        totalHelpers++;
    }

    public void AddRateOfFireRank()
    {
        rateOfFireRank++;
    }

    public int GetRateOfFireRank()
    {
        return rateOfFireRank;
    }

    public void AddScoreMultiplierRank()
    {
        scoreMultiplierRank++;
    }

    public int GetScoreMultiplierRank()
    {
        return scoreMultiplierRank;
    }
}

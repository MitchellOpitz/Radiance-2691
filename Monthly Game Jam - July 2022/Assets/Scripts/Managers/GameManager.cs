using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject unspentPoints;

    // Private variables
    private int shopPoints;
    private int totalHelpers;
    private int rateOfFireRank;
    private int scoreMultiplierRank;
    private int damageMultiplierRank;

    private void Awake()
    {
        shopPoints = 8;
        totalHelpers = 0;
        rateOfFireRank = 0;
    }

    public void AddShopPoint()
    {
        shopPoints++;
        unspentPoints.SetActive(true);
    }

    public void SpendPoint()
    {
        shopPoints--;
        if (shopPoints == 0)
        {
            unspentPoints.SetActive(false);
        }
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

    public void AddDamageMultiplierRank()
    {
        damageMultiplierRank++;
    }

    public int GetDamageMultiplierRank()
    {
        return damageMultiplierRank;
    }
}

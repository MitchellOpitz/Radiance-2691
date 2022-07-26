using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Private variables
    private int shopPoints;
    private int totalHelpers;

    private void Awake()
    {
        shopPoints = 0;
        totalHelpers = 0;
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
}

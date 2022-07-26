using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Private variables
    private int shopPoints;

    private void Awake()
    {
        shopPoints = 0;
    }

    public void AddShopPoint()
    {
        shopPoints++;
        // Debug.Log("Total Shop Points: " + shopPoints);
    }

    public int GetShopPoints()
    {
        return shopPoints;
    }
}

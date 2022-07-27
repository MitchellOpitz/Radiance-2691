using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseRateOfFire : MonoBehaviour
{

    public GameManager gameManager;
    public ShopWindow shopWindow;
    public Text buttonText;

    private int pointsAvailable;
    private int currentRank;

    public void IncreaseRateOfFire()
    {
        pointsAvailable = gameManager.GetShopPoints();
        currentRank = gameManager.GetRateOfFireRank();

        if (pointsAvailable > 0 && currentRank < 8)
        {
            gameManager.SpendPoint();
            gameManager.AddRateOfFireRank();
            shopWindow.DisplayShopPoints();

            if (currentRank == 7)
            {
                gameObject.GetComponent<Button>().interactable = false;
                buttonText.text = "MAX";
            }
        }
    }
}

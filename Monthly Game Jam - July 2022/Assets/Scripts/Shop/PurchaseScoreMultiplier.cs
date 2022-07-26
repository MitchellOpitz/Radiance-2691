using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseScoreMultiplier : MonoBehaviour
{

    public GameManager gameManager;
    public ShopWindow shopWindow;
    public Text buttonText;

    private int pointsAvailable;
    private int currentRank;

    public void PurchaseScoreMultiplierRank()
    {
        pointsAvailable = gameManager.GetShopPoints();
        currentRank = gameManager.GetScoreMultiplierRank();

        if (pointsAvailable > 0 && currentRank < 8)
        {
            gameManager.SpendPoint();
            gameManager.AddScoreMultiplierRank();
            shopWindow.DisplayShopPoints();

            if (currentRank == 7)
            {
                gameObject.GetComponent<Button>().interactable = false;
                buttonText.text = "Max";
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseHelper : MonoBehaviour
{

    public GameManager gameManager;

    private int pointsAvailable;
    private int numberOfHelpers;
    public GameObject redHelper;
    public GameObject orangeHelper;
    public GameObject yellowHelper;
    public GameObject greenHelper;
    public GameObject tealHelper;
    public GameObject blueHelper;
    public GameObject purpleHelper;
    public GameObject pinkHelper;

    public void PurchaseNewHelper()
    {
        pointsAvailable = gameManager.GetShopPoints();
        numberOfHelpers = gameManager.GetTotalHelpers();

        if (pointsAvailable > 0 && numberOfHelpers < 8)
        {
            switch (numberOfHelpers)
            {
                case 0:
                    redHelper.SetActive(true);
                    break;
                case 1:
                    orangeHelper.SetActive(true);
                    break;
                case 2:
                    yellowHelper.SetActive(true);
                    break;
                case 3:
                    greenHelper.SetActive(true);
                    break;
                case 4:
                    tealHelper.SetActive(true);
                    break;
                case 5:
                    blueHelper.SetActive(true);
                    break;
                case 6:
                    purpleHelper.SetActive(true);
                    break;
                case 7:
                    pinkHelper.SetActive(true);
                    gameObject.GetComponent<Button>().interactable = false;
                    break;
            }
            gameManager.SpendPoint();
            gameManager.AddHelper();
        }
    }
}

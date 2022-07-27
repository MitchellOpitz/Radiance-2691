using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{

    // Public variables
    public GameObject shopWindow;
    public Pause pauseMenu;
    public GameManager gameManager;
    public Text pointsAvailable;

    public bool shopOpen = false;

    private void Update()
    {
        if (shopOpen && Input.GetButtonDown("Cancel")){
            CloseShopWindow();
        }
    }

    public void OpenShowWindow()
    {
        shopOpen = true;
        pauseMenu.setGameplayMode(0);
        shopWindow.SetActive(true);
        DisplayShopPoints();
    }

    public void CloseShopWindow()
    {
        shopOpen = false;
        pauseMenu.setGameplayMode(1);
        shopWindow.SetActive(false);
    }

    public void DisplayShopPoints()
    {
        pointsAvailable.text = "POINTS AVAILABLE: " + gameManager.GetShopPoints();
    }
}

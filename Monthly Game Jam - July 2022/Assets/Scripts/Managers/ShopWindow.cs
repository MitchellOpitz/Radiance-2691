using System.Collections;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{

    // Public variables
    public GameObject shopWindow;
    public Pause pauseMenu;

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
    }

    public void CloseShopWindow()
    {
        shopOpen = false;
        pauseMenu.setGameplayMode(1);
        shopWindow.SetActive(false);
    }
}

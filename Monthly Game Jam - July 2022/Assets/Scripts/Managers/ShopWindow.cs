using System.Collections;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{

    public GameObject shopWindow;

    public void OpenShowWindow()
    {
        shopWindow.SetActive(true);
    }

    public void CloseShopWindow()
    {
        shopWindow.SetActive(false);
    }
}

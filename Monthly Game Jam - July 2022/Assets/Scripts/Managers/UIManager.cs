using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Public variables
    public Image XPBarImage;
    public Text levelText;

    public void UpdateLevelText(string level)
    {
        levelText.text = ("LEVEL: " + level);
    }

    public void UpdateXPBar(float percentage)
    {
        XPBarImage.fillAmount = percentage;
    }
}

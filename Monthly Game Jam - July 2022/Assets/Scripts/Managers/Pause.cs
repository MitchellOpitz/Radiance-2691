using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private float gameplayMode = 1;

    public void setGameplayMode(float mode)
    {
        gameplayMode = mode;
        Time.timeScale = gameplayMode;
    }
}

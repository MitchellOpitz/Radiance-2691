using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public LevelLoader levelLoader;

    public void PlayGame()
    {
        levelLoader.LoadNextLevel(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        levelLoader.LoadNextLevel(0);
    }

    public void LoadCredits()
    {
        levelLoader.LoadNextLevel(2);
    }
}

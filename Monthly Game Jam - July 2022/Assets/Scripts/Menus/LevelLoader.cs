using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public void LoadNextLevel(int nextLevel)
    {
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.Play("Crossfade_Start");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    [SerializeField] private int homeScreenIndex;
    [SerializeField] private int firstLevelIndex;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt(MoveToNextLevel.LEVEL_AT, firstLevelIndex);
        GoHome();
    }

    public void GoHome()
    {
        SceneManager.LoadScene(homeScreenIndex);
    }

}

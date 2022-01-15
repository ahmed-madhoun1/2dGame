using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GeneralController : MonoBehaviour
{

    [SerializeField] private int levelsScreenIndex;
    [SerializeField] private GameObject exitLevelDialog;

    private void Start()
    {
        HideExitLevelDialog();
    }

    public void GoToLevelsScreen()
    {
        SceneManager.LoadScene(levelsScreenIndex);
    }

    public void ShowExitLevelDialog()
    {
        exitLevelDialog.SetActive(true);
    }

    public void HideExitLevelDialog()
    {
        exitLevelDialog.SetActive(false);
    }
}

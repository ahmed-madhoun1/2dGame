using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        
        int levelAt = PlayerPrefs.GetInt(MoveToNextLevel.LEVEL_AT, 2); // (2 == Level 1)

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                levelButtons[i].interactable = false;
        }
    }
    public void OpenLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

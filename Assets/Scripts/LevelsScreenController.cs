using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsScreenController : MonoBehaviour
{

    private bool isBackClicked = false;

    private void Update()
    {
        OnBackButtonClicked();
    }

    /*
     * Handle back button clicked ( Keyboard + UI Button )
     */
    private void OnBackButtonClicked()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || isBackClicked)
        {
            // Go to previose scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            isBackClicked = false;
        }
    }

    public void OnBackClicked()
    {
        isBackClicked = true;
    }
}

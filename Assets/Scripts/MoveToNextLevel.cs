using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public const string LEVEL_AT = "levelAt";
    private AudioSource finishSoundEffect;
    private bool levelCompleted = false;

    private void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    /**
     * When the player toutched finish object it will play the finishSoundEffect and start the next level
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSoundEffect.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    //Move to next level
    private void CompleteLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //Move to next level
        SceneManager.LoadScene(nextSceneIndex);
        // Save the last level that the player achieved
        if (nextSceneIndex > PlayerPrefs.GetInt(LEVEL_AT))
        {
            PlayerPrefs.SetInt(LEVEL_AT, nextSceneIndex);
        }
    }
}

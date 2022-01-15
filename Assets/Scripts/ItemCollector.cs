using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int fruits = 0;
    [SerializeField] private Text fruitsText;
    [SerializeField] private AudioSource collectSoundEffect;

    /*
     * This Function Will Listen For Any Game Object Toutchs The Player It Will Take His Collider2D
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectibles"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits++;
            fruitsText.text = fruits.ToString();
        }
    }   

}

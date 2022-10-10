using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private Text fruitsText;
    private int fruits = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fruits"))
        {
            collectSoundEffect.Play();
            fruits++;
            fruitsText.text = "Points: " + fruits + "/10";
        }
    }
}

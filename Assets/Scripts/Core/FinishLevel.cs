using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private float nextLevelDelay;
    private AudioSource finishSoundEffect;
    private bool isLevelCompleted = false;
    
    private void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !isLevelCompleted)
        {
            finishSoundEffect.Play();
            isLevelCompleted = true;
            Invoke("CompleteLevel", nextLevelDelay);
            //make player unable to move after touching flag
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //add gameover / end game screen
    }

}

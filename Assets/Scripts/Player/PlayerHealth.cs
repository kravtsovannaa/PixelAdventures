using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource deathSoundEffect;
    private Rigidbody2D player;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        player.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

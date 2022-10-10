using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Animator anim;
    private bool collected;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(Collected());
        }
    }

    private IEnumerator Collected()
    {
        collected = true;
        anim.SetBool("collected", collected);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}

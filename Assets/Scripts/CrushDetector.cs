using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushDetector : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip audioSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            if (FindObjectOfType<PlayerController>().canMove)
            {
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(audioSFX);
                FindObjectOfType<PlayerController>().DisableControl();
                Invoke("Crash", delay);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Stone")
        {
            if (FindObjectOfType<PlayerController>().canMove)
            {
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(audioSFX);
                FindObjectOfType<PlayerController>().DisableControl();
                Invoke("Crash", delay);
            }

        }


    }


    void Crash()
    {
        Debug.Log("Where is my head?");
        SceneManager.LoadScene(0);

    }

}

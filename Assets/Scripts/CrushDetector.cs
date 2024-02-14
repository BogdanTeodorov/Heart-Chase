using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushDetector : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip audioSFX;
    public int lives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI gameOverText;


    Vector3 respawnPosition; // Store the respawn position
    Quaternion respawnRotation;

    void Start()
    {
        gameOverText.text = "";
        respawnRotation = transform.rotation;
        respawnPosition = transform.position; // Set the respawn position to the player's initial position
        UpdateLivesText(); // Update lives text when the game starts
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            if (FindObjectOfType<PlayerController>().canMove)
            {
                crashEffect.Play();
                LoseLife(); // Player loses a life
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
                LoseLife(); // Player loses a life
            }
        }
    }

    void LoseLife()
    {
        lives--;
        GetComponent<AudioSource>().PlayOneShot(audioSFX);
        FindObjectOfType<PlayerController>().DisableControl();
        UpdateLivesText(); // Update lives text after losing a life
        Invoke("Respawn", delay); // Call Respawn after delay
    }

    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    void Respawn()
    {
        UpdateLivesText(); // Update lives text after losing a life
        if (lives <= 0)
        {
            // Game over logic goes here
            // For now, just reload the scene
            gameOverText.text = "Game Over! Press ESC to enter Menu";
            Time.timeScale = 0f;
            FindObjectOfType<SurfaceEffector2D>().speed = 0;
            //SceneManager.LoadScene(FindObjectOfType<FinishLine>().levelIndex);
        }
        else
        {
            // Respawn the player at the beginning of the level
            transform.rotation = respawnRotation;
            transform.position = respawnPosition;
            FindObjectOfType<PlayerController>().canMove = true; // Enable player control
        }
    }
}

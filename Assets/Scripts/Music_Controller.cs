using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Controller : MonoBehaviour
{
    [SerializeField] AudioClip lvlOneMusic;
    [SerializeField] AudioClip lvlTwoMusic;
    [SerializeField] AudioClip gameOverMusic;
    [SerializeField] AudioClip victoryMusic;

    int levelIndex;
    int playerLives;
    bool isOver;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        isOver = true;


        // Start playing the appropriate level music based on the current scene index
        if (levelIndex == 0)
        {
            PlayLevelMusic(lvlOneMusic);
        }
        else if (levelIndex == 1)
        {
            PlayLevelMusic(lvlTwoMusic);
        }
    }

    void Update()
    {

        // Check the player's remaining lives
        playerLives = FindObjectOfType<CrushDetector>().lives;

        // If player runs out of lives, play game over music and stop level music
        if (playerLives <= 0 && isOver)
        {
            StopLevelMusic();
            PlayGameOverMusic();
            isOver = false;
        }
        else if (playerLives > 0 && FindObjectOfType<FinishLine>().isWon)
        {

            StopLevelMusic();
            PlayVictoryMusic();
            FindObjectOfType<FinishLine>().isWon = false;


        }
    }

    // Function to play the level music
    void PlayLevelMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }

    // Function to stop the level music
    void StopLevelMusic()
    {
        audioSource.Stop();
    }

    void PlayVictoryMusic()
    {
        audioSource.loop = false;
        audioSource.clip = victoryMusic;
        audioSource.Play();
    }


    // Function to play the game over music
    void PlayGameOverMusic()
    {
        audioSource.loop = false;
        audioSource.clip = gameOverMusic;
        audioSource.Play();
    }
}

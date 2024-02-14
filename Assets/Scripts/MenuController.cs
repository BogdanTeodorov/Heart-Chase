using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI; // Reference to the pause menu UI panel
    [SerializeField] AudioSource musicController; // Reference to the music controller AudioSource

    private bool isPaused = false; // Flag to track whether the game is paused
    private bool musicWasPlaying = false; // Flag to track whether the music was playing before pausing

    void Start()
    {
        HidePauseMenu(); // Hide the pause menu when the game starts
    }

    void Update()
    {
        // Check for input to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    // Function to pause the game
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Set time scale to 0 to pause the game
        musicWasPlaying = musicController.isPlaying; // Remember whether music was playing
        if (musicWasPlaying)
            musicController.Pause(); // Pause the music
        ShowPauseMenu(); // Show the pause menu
    }

    // Function to resume the game
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f; // Set time scale back to 1 to resume the game
        if (musicWasPlaying)
            musicController.UnPause(); // Resume the music if it was playing before
        HidePauseMenu(); // Hide the pause menu
    }

    // Function to show the pause menu
    public void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    // Function to hide the pause menu
    void HidePauseMenu()
    {
        pauseMenuUI.SetActive(false);
    }

    // Function to load the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");
        Resume(); // Make sure to resume the game when starting or restarting the game
    }

    // Function to restart the current scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume(); // Make sure to resume the game after restarting
    }

    // Function to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}

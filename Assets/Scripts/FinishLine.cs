using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Index of current level
    public int levelIndex;
    // Trigger variable to prevent double triggering of the event
    bool isTriggered;
    // Max amount of hearts on each level
    int maxHearts;
    public bool isWon;



    // Required hearts to pass the level
    [SerializeField] int reqHearts;
    // Delay before showing the menu
    [SerializeField] float menuDelay = 1.5f;
    // Delay before reloading the level or showing the menu
    [SerializeField] float delay = 0.5f;
    // Particle system for finish effect
    [SerializeField] ParticleSystem finishEffect;
    // Text object for displaying rank
    [SerializeField] TMPro.TextMeshProUGUI rankText;
    [SerializeField] AudioClip lvlMusic;

    int maxLevelIndex;

    void Start()
    {
        rankText.text = "";
        isTriggered = false;
        isWon = false;
        maxHearts = 11;
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        maxLevelIndex = 2; // Index of the last level
        Debug.Log("Maximum amount of hearts on the level is " + maxHearts.ToString());
        Debug.Log("Start level index is " + levelIndex.ToString());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered)
        {
            if (other.tag == "Player")
            {
                int counter = FindObjectOfType<Heart_Controller>().heartCounter;

                if (counter > reqHearts)
                {
                    levelIndex++;
                    Debug.Log("Play level with index " + levelIndex.ToString());

                    if (counter >= maxHearts)
                    {
                        rankText.text = "Perfect S Rank!!!";
                    }
                    else if (counter >= 8 && counter < maxHearts)
                    {
                        rankText.text = "Excellent A Rank";
                    }
                    else if (counter < 8 && counter > reqHearts)
                    {
                        rankText.text = "Good job";
                    }

                    if (levelIndex == maxLevelIndex)
                    {
                        isWon = true;
                        Invoke("ShowCongrats", delay);
                    }
                    else
                    {
                        Invoke("Reload", delay);
                    }
                }
                else if (counter > 0 && counter <= reqHearts)
                {
                    rankText.text = "Sorry not enough hearts. Let's try again";
                    Debug.Log("Same index cause you don't have enough hearts");
                    Invoke("Reload", delay);
                }

                isTriggered = true;
                Debug.Log("Finish line was triggered");
                finishEffect.Play(); // particles 
                GetComponent<AudioSource>().Play(); // music
            }
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(levelIndex);
    }

    void ShowCongrats()
    {
        Debug.Log("Congrats");
        rankText.text = "You won!\n You are a real heart chaser!\n Press ESC to enter menu";
        Time.timeScale = 0; // Pause the game

    }


}

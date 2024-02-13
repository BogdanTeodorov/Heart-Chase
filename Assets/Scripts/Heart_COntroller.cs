using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI to access the Text class

public class Heart_Controller : MonoBehaviour
{
    public int heartCounter;
    [SerializeField] AudioClip pickUpEffect;
    [SerializeField] TextMeshProUGUI heartCountRender;

    // Start is called before the first frame update
    void Start()
    {
        heartCounter = 0;
        UpdateHeartCounterText(); // Update the text content when the game starts

        // Generate object in random place

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Heart") // Use CompareTag for performance
        {
            heartCounter++;
            FindObjectOfType<Candy_Controller>().score += 50;
            GetComponent<AudioSource>().PlayOneShot(pickUpEffect);
            UpdateHeartCounterText(); // Update the text content when a heart is picked up
            Destroy(other.gameObject);
        }

    }

    // Update the UI Text content with the current heart counter
    public void UpdateHeartCounterText()
    {
        heartCountRender.text = "Hearts: " + heartCounter.ToString();
        FindObjectOfType<Candy_Controller>().scoreBoard.text = "Score: " + FindObjectOfType<Candy_Controller>().score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

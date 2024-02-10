using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI to access the Text class

public class Heart_Controller : MonoBehaviour
{
    int heartCounter;
    [SerializeField] AudioClip pickUpEffect;
    // [SerializeField] TextMeshPro heartCountRender;
    public Text heartCounterText; // Reference to the UI Text component

    // Start is called before the first frame update
    void Start()
    {
        heartCounter = 0;
        // UpdateHeartCounterText(); // Update the text content when the game starts
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heart")) // Use CompareTag for performance
        {
            heartCounter++;
            GetComponent<AudioSource>().PlayOneShot(pickUpEffect);
            Debug.Log("Heart has been picked up " + heartCounter);
            Destroy(other.gameObject);
            // UpdateHeartCounterText(); // Update the text content when a heart is picked up
        }
    }

    // Update the UI Text content with the current heart counter
    // void UpdateHeartCounterText()
    // {
    //     if (heartCounterText != null && heartCountRender != null) // Ensure the reference is not null
    //     {
    //         heartCounterText.text = "Hearts: " + heartCounter.ToString();
    //         heartCountRender.text = heartCounterText.text;
    //     }
    // }

    // Update is called once per frame
    void Update()
    {

    }
}

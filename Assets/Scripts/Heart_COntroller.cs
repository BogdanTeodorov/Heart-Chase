using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI to access the Text class

public class Heart_Controller : MonoBehaviour
{
    public int heartCounter;
    [SerializeField] AudioClip pickUpEffect;
    public Text heartCounterText; // Reference to the UI Text component
    [SerializeField] TextMeshProUGUI heartCountRender;

    public GameObject item;

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
            GetComponent<AudioSource>().PlayOneShot(pickUpEffect);
            Debug.Log("Heart has been picked up " + heartCounter);
            UpdateHeartCounterText(); // Update the text content when a heart is picked up
            Destroy(other.gameObject);
        }

    }

    // Update the UI Text content with the current heart counter
    public void UpdateHeartCounterText()
    {
        heartCountRender.text = "Hearts: " + heartCounter.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}

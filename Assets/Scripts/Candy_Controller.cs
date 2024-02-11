using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_Controller : MonoBehaviour
{
    int candyCounter;
    [SerializeField] AudioClip pickUpEffect;
    [SerializeField] int candyModule = 10;

    // Start is called before the first frame update
    void Start()
    {
        candyCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Candy") // Use CompareTag for performance
        {

            candyCounter++;
            GetComponent<AudioSource>().PlayOneShot(pickUpEffect);
            Debug.Log("Candy has been picked up " + candyCounter);
            //UpdateHeartCounterText(); // Update the text content when a heart is picked up
            Destroy(other.gameObject);
            if (candyCounter % candyModule == 0)
            {
                FindObjectOfType<Heart_Controller>().heartCounter++;
                FindObjectOfType<Heart_Controller>().UpdateHeartCounterText();
            }
        }

    }
}

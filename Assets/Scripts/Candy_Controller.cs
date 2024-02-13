using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Candy_Controller : MonoBehaviour
{
    int candyCounter;
    [SerializeField] AudioClip pickUpEffect;
    [SerializeField] int candyModule = 10;
    public TextMeshProUGUI scoreBoard;
    public int score = 0;

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
            score += 10;
            GetComponent<AudioSource>().PlayOneShot(pickUpEffect);
            scoreBoard.text = "Score: " + score.ToString();
            Destroy(other.gameObject);
            if (candyCounter % candyModule == 0)
            {
                FindObjectOfType<Heart_Controller>().heartCounter++;
                FindObjectOfType<Heart_Controller>().UpdateHeartCounterText();
            }
        }

    }
}

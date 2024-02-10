using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_COntroller : MonoBehaviour
{
    int heartCounter;


    // Start is called before the first frame update
    void Start()
    {
        heartCounter = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Heart")
        {
            heartCounter++;
            Debug.Log("Heart has been picked up " + heartCounter);
            Destroy(other.gameObject);
            // Destroy(other);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

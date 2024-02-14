using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TricksController : MonoBehaviour
{
    public int trickScore = 5; // Score for trick
    float previousRotation = 0f;
    float totalScore;

    void Start()
    {
        totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float currentRotation = 0f;
        float rotationChange = 0f; // Accumulate rotation change over multiple frames


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && !GetComponent<PlayerController>().canJump)
        {
            currentRotation = transform.eulerAngles.z;

            // Calculate the difference in rotation
            rotationChange += Mathf.Abs(currentRotation - previousRotation);

            if (rotationChange >= 100f)
            {
                FindObjectOfType<Candy_Controller>().score += trickScore;
                FindObjectOfType<Heart_Controller>().UpdateHeartCounterText();
                // Update previousRotation to current rotation
                previousRotation = currentRotation;

            }
        }


    }


}


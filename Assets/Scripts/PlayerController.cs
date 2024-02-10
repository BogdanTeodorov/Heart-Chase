using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float regularSpeed = 10f;
    [SerializeField] float torqueAmount = 2f;
    [SerializeField] float jumpForce = 500f; // Jump force
    public bool canMove = true;
    public bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            PlayerInput();
            RespondToBoost();

        }
    }

    public void DisableControl()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = regularSpeed;
        }
    }

    private void PlayerInput()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(torqueAmount * -1);
        }
        // Call Jump method when space key is pressed
        else if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }
    }
    private void Jump()
    {
        // Apply jump force if grounded
        rb2d.AddForce(Vector2.up * jumpForce);
    }
}

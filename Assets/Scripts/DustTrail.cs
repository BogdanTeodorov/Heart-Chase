using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }




    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerController != null)
        {
            playerController.canJump = true;
            ps.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerController != null)
        {
            playerController.canJump = false;
            ps.Stop();
        }
    }





}

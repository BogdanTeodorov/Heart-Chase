using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    void Start()
    {
        // ps = GetComponent<ParticleSystem>();
    }




    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            ps.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            ps.Stop();
        }
    }





}

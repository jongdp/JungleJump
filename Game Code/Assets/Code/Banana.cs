using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /// <summary>
    /// Destroys objects that have left the screen via a platform
    /// Note: This function is part of the MonoBehavior class from the Unity
    /// Engine
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Detects whether the collision with the banana gameobject was caused by
    /// the main character tagged "monkey" and increments the score.
    /// </summary>
    /// <param name="collision"> This is an instance of the Collision2D class
    /// provided by Unity </param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("monkey"))
        {
            Destroy(gameObject);
            ScoreKeeper.AddToScore(1);
        }
    }
}

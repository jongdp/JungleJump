using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    ///// <summary>
    /// Destroys objects that have left the screen.
    /// Note: This function is part of the MonoBehavior class from the Unity
    /// Engine
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Unity callback called automatically when the GameObject is no longer visible by any camera.
    /// If the collider belongs to a GameObject tagged as "monkey", this object is destroyed
    /// and the player's score is increased by 1.
    /// </summary>
    /// <param name="collision">Collision information provided by Unity.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("monkey"))
        {
            Destroy(gameObject);
            ScoreKeeper.AddToScore(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver gameOver; // Static instance of the GameOver class for global access.
    public GameObject text; // UI GameObject that displays the "Game Over" text on screen.
    public AudioClip gameOverSound;
    private AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        gameOver = this;
        text.SetActive(false);
        audioSource = GetComponent<AudioSource>();

    }

    /// <summary>
    /// Static function wrapper that internally calls gameOver.EndGameInternal()
    /// to actually end the game.
    /// Note: Allows the function to get called globally (i.e., does not require
    /// an instance of an object to call the EndGame() function).
    /// (i.e., this implementation) of the game.
    /// </summary>
    public static void EndGame()
    {
        gameOver.EndGameInternal();
    }

    /// <summary>
    /// Activates the "Game Over" text and plays a sound indicating that the
    /// player has lost.
    /// </summary>
    public void EndGameInternal()
    {
        text.SetActive(true);
        audioSource.PlayOneShot(gameOverSound);
    }
}
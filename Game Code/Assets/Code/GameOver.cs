using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver gameOver;
    public GameObject text;
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
    /// Note: Allows the function to get called globally and not for a
    /// particular instance of a GameOver object which goes against the design
    /// (i.e., this implementation) of the game.
    /// </summary>
    public static void EndGame()
    {
        gameOver.EndGameInternal();
    }

    /// <summary>
    /// 
    /// </summary>
    public void EndGameInternal()
    {
        text.SetActive(true);
        audioSource.PlayOneShot(gameOverSound);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>  </returns>
    public static bool isGameOver()
    {
        return gameOver.text.activeInHierarchy;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver gameOver;
    public GameObject text;
    public AudioClip gameOverSound;
    private AudioSource audioSource;
    private bool soundPlayed;

    void Start()
    {
        gameOver = this;
        text.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        soundPlayed = false;

    }

    public static void EndGame()
    {
        gameOver.EndGameInternal();
    }

    public void EndGameInternal()
    {
        text.SetActive(true);
        if (!soundPlayed)
        {
            soundPlayed = true;
            audioSource.PlayOneShot(gameOverSound);
        }
    }

    public static bool isGameOver()
    {
        return gameOver.text.activeInHierarchy;
    }
}
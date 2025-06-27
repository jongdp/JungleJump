using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper sk;
    private static float score;
    private static Text scoreText;
    public AudioClip scoreSound;
    private AudioSource audioSource;

    /// <summary>
    /// Unity's Start method, called on initialization.
    /// Initializes references to Text and AudioSource components,
    /// updates the score display, and sets the singleton instance.
    /// </summary>
    internal void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateText();
        audioSource = GetComponent<AudioSource>();
        ScoreKeeper.sk = FindObjectOfType<ScoreKeeper>();

    }

    /// <summary>
    /// Adds points to the score, updates the displayed text,
    /// and plays the score increment sound.
    /// </summary>
    /// <param name="points">Amount of points to add.</param>
    public static void AddToScore(float points)
    {
        score += points;
        UpdateText();
        sk.playSound();
    }

    /// <summary>
    /// Plays the assigned score sound once using the AudioSource.
    /// </summary>
    public void playSound()
    {
        audioSource.PlayOneShot(scoreSound);

    }

    /// <summary>
    /// Updates the UI text element to show the current score.
    /// </summary>
    private static void UpdateText()
    {
        scoreText.text = String.Format("Score: {0}", score);
    }
}

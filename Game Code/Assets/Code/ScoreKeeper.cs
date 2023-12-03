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

    // Use this for initialization
    internal void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateText();
        audioSource = GetComponent<AudioSource>();
        ScoreKeeper.sk = FindObjectOfType<ScoreKeeper>();

    }

    public static void AddToScore(float points)
    {
        score += points;
        UpdateText();
        sk.playSound();
    }

    public void playSound()
    {
        audioSource.PlayOneShot(scoreSound);

    }

    private static void UpdateText()
    {
        scoreText.text = String.Format("Score: {0}", score);
    }
}

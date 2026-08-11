using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Device;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen gameOverScreen;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public GameObject text;
    public AudioClip gameOverSound;


    /// Note from ChatGPT:
    /// You're noticing that:
    /// Some game objects(like platforms, enemies, or the player) are dynamic — they move, spawn, change, and are tied to the real-time state of the game world.
    /// Others(like UI screens, buttons, or overlays) are interface elements, and they don’t change as often or have multiple instances.

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen = this;
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
        text.SetActive(false);
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
        gameOverScreen.EndGameInternal();
    }

    /// <summary>
    /// Activates the "Game Over" text, buttons, and plays a sound indicating
    /// that the player has lost.
    /// </summary>
    public void EndGameInternal()
    {
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
        text.SetActive(true);
        AudioManager.instance.PlaySoundFXClip(gameOverSound, transform, 1f);
    }

    /// <summary>
    /// 
    /// </summary>
    public void RestartButton()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

}

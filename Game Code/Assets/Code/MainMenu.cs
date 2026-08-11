using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Unity's play method, loads up the scene to be played
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

}

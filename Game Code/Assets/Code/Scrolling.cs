using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{
    public float speed;
    public Renderer bgrenderer;

    /// <summary>
    /// Unity's update method, called once per frame.
    /// Updates the texture offset based on speed and time to animate scrolling.
    /// </summary>
    void Update()
    {
        bgrenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}

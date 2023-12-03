using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{
    public float speed;
    public Renderer bgrenderer;


    void Update()
    {
        bgrenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBodyPlatform;


    // Start is called before the first frame update
    void Start()
    {
        rigidBodyPlatform = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newVelocity = new Vector2(-7f, 0f);
        rigidBodyPlatform.velocity = newVelocity;
    }

    /// <summary>
    /// Unity callback called automatically when the GameObject is no longer visible by any camera.
    /// Destroys the platforms when they leave the screen
    /// </summary>
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

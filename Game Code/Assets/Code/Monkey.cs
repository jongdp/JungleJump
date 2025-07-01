using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3f;
    public float jumpForce = 30f;
    private int groundedContacts;
    public AudioClip jumpSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Maneuver();
        MaybeJump();
    }

    /// <summary>
    /// Reads player input and applies horizontal movement to the Rigidbody2D.
    /// Normalizes the input vector to ensure consistent speed in all directions,
    /// then sets the velocity based on the horizontal input and a movement speed multiplier.
    /// Vertical velocity is preserved to avoid interfering with jumping or gravity.
    /// </summary>
    private void Maneuver()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        direction = direction.normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    /// <summary>
    /// Checks whether the player is allowed to jump (e.g., pressing jump input and grounded).
    /// If conditions are met, triggers the actual jump logic.
    /// </summary>
    private void MaybeJump()
    {
        if ((Input.GetAxis("Jump") == 1) && IsGrounded())
        {
            Jump();
        }
    }

    /// <summary>
    /// Applies upward force to simulate a jump, resets vertical velocity,
    /// and plays a jump sound. Assumes jump conditions have already been validated.
    /// </summary>
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioSource.PlayOneShot(jumpSound);
    }


    /// <summary>
    /// Returns whether the player character is currently grounded.
    /// Grounded status is used to determine if jumping is allowed.
    /// </summary>
    /// <returns>True if the player is on a platform; false otherwise.</returns>
    private bool IsGrounded()
    {
        return groundedContacts > 0;
    }

    /// <summary>
    /// Unity callback that is triggered when this GameObject starts colliding with another 2D collider.
    /// Sets the grounded flag to true when colliding with the "platform" GameObject.
    /// </summary>
    /// <param name="collision">Collision information provided by Unity.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            groundedContacts++;
        }
    }

    /// <summary>
    /// Unity callback that is triggered when this GameObject stops colliding with another 2D collider.
    /// Sets the grounded flag to false when leaving a "platform" GameObject.
    /// </summary>
    /// <param name="collision">Collision information provided by Unity.</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            groundedContacts--;
        }
    }

    /// <summary>
    /// Unity callback called automatically when the GameObject is no longer visible by any camera.
    /// Checks whether the object has fallen too far off-screen (horizontally or vertically),
    /// and if so, ends the game and destroys the player GameObject.
    /// </summary>
    private void OnBecameInvisible()
    {
        var y = transform.position.y;
        var x = transform.position.x;
        if (y < -5 || x < -9)
        {
            GameOver.EndGame();
            Destroy(gameObject);
        }
    }
}

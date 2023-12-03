using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3f;
    public float jumpForce = 30f;
    private bool grounded;
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

    private void Maneuver()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        direction = direction.normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    private void MaybeJump()
    {
        if ((Input.GetAxis("Jump") == 1) && IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioSource.PlayOneShot(jumpSound);
    }

    private bool IsGrounded()
    {
        return grounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            grounded = false;
        }
    }

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

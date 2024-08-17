using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public FixedJoystick fixedJoystick; 
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "walk"; 
    private string JUMP_ANIMATION = "walk"; 
    public float jumpForce = 7.5f;
    private bool isGrounded = true; 

    // Audio components
    public AudioSource audioSource;
    public AudioClip lost;
   
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>(); 
        sr = gameObject.GetComponent<SpriteRenderer>(); 
    }
    
    void Update()
    {
        movePlayer(); // Call the movePlayer method
    }
    
    void movePlayer()
    { 
        float horizontalValue = fixedJoystick.Horizontal;
        float verticalValue = fixedJoystick.Vertical;

        rb.velocity = new Vector2(horizontalValue * 5, rb.velocity.y); // Move the player horizontally
        animatePlayerHorizontal(horizontalValue);

        if (verticalValue > 0.5f && isGrounded) // Check if the joystick is pushed upwards and player is grounded
        {
            Jump();
            animatePlayerVertical(verticalValue);
        }
    }
    
    void animatePlayerHorizontal(float horizontalValue)
    {
        if (horizontalValue != 0) // Check if the player is moving
        {
            if (horizontalValue > 0) // Check if the player is moving right
            {
                sr.flipX = false; // Set the player sprite to face right
            }
            else if (horizontalValue < 0) // Check if the player is moving left
            {
                sr.flipX = true; // Set the player sprite to face left
            }
            anim.SetBool(WALK_ANIMATION, true); // Start walk animation
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false); // Stop walk animation
        }
    }

    void animatePlayerVertical(float verticalValue)
    {
        if (verticalValue > 0.5f) // Check if the joystick is pushed upwards
        {
            anim.SetBool(JUMP_ANIMATION, true); // Start jump animation
            anim.SetBool(WALK_ANIMATION, false); // Stop walk animation
        }
        else
        {
            anim.SetBool(JUMP_ANIMATION, false); // Stop jump animation
        }
    }
    
    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        isGrounded = false; // Set grounded to false after jumping
    }

    // Detect when player lands on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set grounded to true when player touches the ground
            anim.SetBool(JUMP_ANIMATION, false); // Stop jump animation           
        }

        if (collision.gameObject.CompareTag("enemy")){
            Destroy(gameObject);
            SceneManager.LoadScene("loose");
        }
        if (collision.gameObject.CompareTag("missionComplete")){
            Destroy(gameObject);
            SceneManager.LoadScene("MissionComplete");
        }
    }


}

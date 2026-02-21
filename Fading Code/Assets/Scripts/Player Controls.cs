using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    public float moveSpd;
    public enum Direction
    {
        Left,
        Right
    }
    public Direction facing;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float moveInput;

    public float jumpPower = 10f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    private bool jumpPressed;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

     // Update is called once per frame
    void FixedUpdate()
    {
        movement();

        if (jumpPressed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }

        jumpPressed = false; // reset the one-frame flag


    }


    // FUNCTIONS
    private void movement()
    {
        //change direction of the player
        //+ if right
        if(moveInput > 0)
        {
            sr.flipX = false;
            facing = Direction.Right;
        }
        else if(moveInput < 0)
        {
            sr.flipX = true;
            facing = Direction.Left;
        }
        //else, which is no move input, do nothing to save last direction

        //apply movement
        rb.linearVelocityX = moveInput * moveSpd;
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    // ACTION INPUT SYSTEM FUNCTIONS
    /*
    Gets the direction of the input 
    as a positive or negative value (-1, 1)
    based on bindings connected to the Move action in the Input System asset
    */
    private void OnMove(InputValue input)
    {
        moveInput = input.Get<float>();
    }

    private void OnJump(InputValue input)
    {
        if (input.isPressed) jumpPressed = true;
    }

}

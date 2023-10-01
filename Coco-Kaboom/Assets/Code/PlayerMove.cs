using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Controls playerControls;

    [SerializeField]
    private float speed, smoothMove, jumpStartTime, checkRadius, jumpForce;

    [SerializeField]
    private LayerMask ground;

    [SerializeField]
    private Transform feetPos;

    private float jumpTime;

    private bool isJumping, isGrounded;

    private Rigidbody2D player;

    private Vector2 move;
    private Vector2 jump;

    private Vector2 baseVel = Vector2.zero;

    private void Awake()
    {
        playerControls = new Controls();
    }

    // Enables player controls
    private void OnEnable()
    {
        playerControls.Enable();
    }

    // Disables player controls
    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        // Initiates player rigidbody component
        player = gameObject.GetComponent<Rigidbody2D>();

        // When jump is performed call method Jump()
        playerControls.Movement.Jump.started += _ => Jump();
    }

    private void Update()
    {
        Flip();

        // Checks if the players "feet" are touching what constitutes the ground
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);

        //checks if jump is being held
        isJumping = playerControls.Movement.Jump.ReadValue<float>() > 0;

        // If player is still in jump, generate height, until max jump time reached
        if (isJumping)
        {
            if (jumpTime > 0)
            {
                player.AddForce(Vector2.up * jumpForce);
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }

    private void FixedUpdate()
    {
        move = playerControls.Movement.Move.ReadValue<Vector2>();

        if (isGrounded)
        {
            // Set the player veloccity based on cardinal direction from controls
            player.velocity = Vector2.SmoothDamp(player.velocity, move * speed, ref baseVel, smoothMove);
        }
        else
        {
            // Set the player veloccity based on cardinal direction from controls, but is in the air so horizontal mobility is halved
            player.velocity = Vector2.SmoothDamp(player.velocity, (move * speed)/2, ref baseVel, smoothMove);
        }

        
    }

    // Chages which direction the player is facing
    void Flip()
    {
        if (player.velocity.x > 0f)
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        if (player.velocity.x < 0f)
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    // Allows player to jump
    void Jump()
    {

        Debug.Log("Jump Pressed");

        // Performs jump
        if (isGrounded)
        {
            jumpTime = jumpStartTime;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Controls playerControls;

    [SerializeField]
    private float speed, smoothMove;

    private Rigidbody2D player;

    private Vector2 move;

    private Vector2 baseVel = Vector2.zero;

    private void Awake()
    {
        playerControls = new Controls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Flip();
    }

    private void FixedUpdate()
    {

        move = playerControls.Movement.Move.ReadValue<Vector2>();

        player.velocity = Vector2.SmoothDamp(player.velocity, move * speed, ref baseVel, smoothMove);
    }

    void Flip()
    {
        if (player.velocity.x > 0f)
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        if (player.velocity.x < 0f)
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
    }
}

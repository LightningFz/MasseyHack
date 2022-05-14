using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovemnet : MonoBehaviour
{
    public float runSpeed = 40;
    public float jumpPower = 5;

    private bool _isJumping = false;
    private bool isGrounded;
    private float horizontal;
    private int jumpCount;

    Rigidbody2D rb;
    BoxCollider2D coll;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        getInput();
    }
    private void FixedUpdate()
    {
        move();
    }

    private void getInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            _isJumping = true;
        }

    }
    private void move()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
        if (_isJumping && jumpCount > 0)
        {
            rb.AddForce(new Vector2(0f, jumpPower));
            jumpCount--;
        }
        _isJumping = false;
    }
}

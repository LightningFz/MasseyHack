using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovemnet : MonoBehaviour
{
    public float runSpeed = 40;
    public float jumpPower = 5;
    public int maxJumps = 1;
    [SerializeField] private float checkRadius;


    private bool _isJumping = false;
    private bool isGrounded;
    private float horizontal;
    private int jumpCount;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundObject;

    Rigidbody2D rb;
    BoxCollider2D coll;
    private void Start()
    {
        jumpCount = maxJumps;
    }
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
        Grounded();
        move();
    }
    private void Grounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObject);
        if (isGrounded)
        {
            jumpCount = maxJumps;
        }
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

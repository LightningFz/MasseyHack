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
    public Animator animator;

    Rigidbody2D rb;
    BoxCollider2D coll;
    Vector2 movement;
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
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("speed", movement.magnitude);
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
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            _isJumping = true;
        }

    }
    private void move()
    {
        rb.velocity = new Vector2(movement.x * runSpeed, rb.velocity.y);
        if (_isJumping && jumpCount > 0)
        {
            rb.AddForce(new Vector2(0f, jumpPower));
            jumpCount--;
        }
        _isJumping = false;
    }
}

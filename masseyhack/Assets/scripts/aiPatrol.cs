using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiPatrol : MonoBehaviour
{
    public bool mustpatrol;
    public bool mustturn;
    public float speed;
    public Transform groundcheck;
    public Rigidbody2D rb;
    public LayerMask groundlayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        mustpatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustpatrol)
        {
            Patrol();
        }
    }
    void FixedUpdate()
    {
        if (mustpatrol)
        {
            mustturn = !Physics2D.OverlapCircle(groundcheck.position, 0.1f, groundlayer); // to make it the opp
        }    
    }
    void Patrol()
    {
        if (mustturn)
        {
            Flip();
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        mustpatrol = false;
        transform.localScale = new Vector2(transform.lossyScale.x * -1, transform.lossyScale.y);
        speed *= -1;
        mustpatrol = true;
    }
}

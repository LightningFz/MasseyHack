using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; 
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "enemy" || hitInfo.tag == "ground")
        {
            enemy enemy = hitInfo.GetComponent<enemy>();
            if (enemy != null)
            {
                enemy.takedamage(20);
            }
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public int DamageAmount = 10;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("damage");
            _Damage(collision);
        }
    }

    void _Damage(Collider2D player)
    {
        playerHealth playerHealth = player.GetComponent<playerHealth>();
        playerHealth.healthSystem.Damage(DamageAmount);
    }
}

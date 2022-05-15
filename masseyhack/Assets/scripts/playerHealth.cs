using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int maxhealth;
    public HealthSystem healthSystem;
    public healthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem(maxhealth);
        healthbar.SetMaxHealth(healthSystem.healthMax);
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        healthbar.SetHealth(healthSystem.health);
    }
    public void Die()
    {
        if (healthSystem.health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
}

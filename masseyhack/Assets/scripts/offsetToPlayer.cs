using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offsetToPlayer : MonoBehaviour
{
    private float horizontal;

    public Transform aim;
    public Transform player;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(1.2f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal == 1)
        {
            offset = new Vector3(1.2f, 0, 0);
            aim.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontal == -1)
        {
            offset = new Vector3(-1.2f, 0, 0);
            aim.rotation = Quaternion.Euler(0, 0, 180);
        }
        aim.position = player.position + offset;
    }
}

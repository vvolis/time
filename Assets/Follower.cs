using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Entity
{
    public GameObject target;
    public float speed = 2;
    public float followDistance = 2.0f;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        Vector3 movement = target.transform.position - transform.position;
        if (movement.magnitude > followDistance)
        {
            movement.Normalize();
            rb2D.velocity = movement * speed;
        } else
        {
            rb2D.velocity = movement * 0;
        }

        base.Update();
    }
}

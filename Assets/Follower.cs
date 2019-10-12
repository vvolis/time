using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject target;
    public float speed = 2;
    public float followDistance = 2.0f;
    private Animator animator;
    private Rigidbody2D rb2D;

    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

       
        if (rb2D.velocity.magnitude > 0)
        {
            animator.SetFloat("moveX", rb2D.velocity.x);
            animator.SetFloat("moveY", rb2D.velocity.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        Vector3 movement = target.transform.position - transform.position;

        if (movement.magnitude > followDistance)
        {
            movement.Normalize();
            //transform.position = transform.position + movement * Time.deltaTime * speed;

            // move the RigidBody2D instead of moving the Transform
            rb2D.velocity = movement * speed;



        } else
        {
            rb2D.velocity = movement * 0;
        }



    }
}

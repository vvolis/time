using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Follower : Entity
{
    public GameObject target;
    public float speed = 2;
    public float followDistance = 2.0f;

    

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        if (DM.Instance != null)
        {
            DM.RegisterPlayer(entityName, this);
        }

        
    }

    // Update is called once per frame
    new void Update()
    {
        if (followEnabled)
        {
            Vector3 movement = followTarget.transform.position - transform.position;
            /*if (movement.magnitude > followDistance)
            {
                //Say("Follow " + target.gameObject.name);
                movement.Normalize();
                rb2D.velocity = movement * speed;
            }
            else
            {
                //Say("Idle");
                rb2D.velocity = movement * 0;
            }*/

            Seeker seeker = GetComponent<Seeker>();

            // Start to calculate a new path to the targetPosition object, return the result to the OnPathComplete method.
            // Path requests are asynchronous, so when the OnPathComplete method is called depends on how long it
            // takes to calculate the path. Usually it is called the next frame.
            seeker.StartPath(transform.position, followTarget.transform.position, OnPathComplete);


            base.Update();
        }
       
    }

    public void OnPathComplete(Path p)
    {
        //Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
    }
}

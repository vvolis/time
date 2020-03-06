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


    private int nextUpdate = 1;

    // Update is called once per frame
    new void Update()
    {
        if (followEnabled)
        {

            Seeker seeker = GetComponent<Seeker>();

            // Start to calculate a new path to the targetPosition object, return the result to the OnPathComplete method.
            // Path requests are asynchronous, so when the OnPathComplete method is called depends on how long it
            // takes to calculate the path. Usually it is called the next frame.
            if (Time.time >= nextUpdate){
                // Change the next update (current second+1)
                nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                // Call your fonction





                //quite likely we need to call this only once!!!!
                seeker.StartPath(transform.position, followTarget.transform.position, OnPathComplete);
            }
          
            base.Update();
        }
       
    }

    public void OnPathComplete(Path p)
    {
        //Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
    }
}

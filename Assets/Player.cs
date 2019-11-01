using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    public float speed = 5.0f;
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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //transform.position = transform.position + movement * Time.deltaTime * speed;

        // move the RigidBody2D instead of moving the Transform
        rb2D.velocity = movement * speed;

        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DM.SendMessage("Sheep booping into something" + collision.gameObject.name);
        Say("I booped into" + collision.gameObject.name);
    }

}

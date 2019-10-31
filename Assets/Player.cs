using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Animator animator;
    public float speed = 5.0f;
    private Rigidbody2D rb2D;
    private SpeechBubble speechBubble;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

        Canvas canvas = Helper.FindComponentInChildWithTag<Canvas>(this.gameObject, "text");
        Text _text = Helper.FindComponentInChildWithTag<Text>(canvas.gameObject, "text");
        speechBubble = new SpeechBubble(_text);
        StartCoroutine(speechBubble.ClearText(1f));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //transform.position = transform.position + movement * Time.deltaTime * speed;

        // move the RigidBody2D instead of moving the Transform
        rb2D.velocity = movement * speed;


        if (movement.magnitude > 0)
        {
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("moving", true);
        } else
        {
            animator.SetBool("moving", false);
        }


        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DM.SendMessage("Sheep booping into something" + collision.gameObject.name);
        SendMessage("I booped into" + collision.gameObject.name);
    }

    new private void SendMessage(string txt)
    {
        speechBubble.SendMessage(txt);
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb2D;
    protected SpeechBubble speechBubble;


    //All Entities have
    //--speech bubble
    //--Movement animation
    //



    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

        Canvas canvas = Helper.FindComponentInChildWithTag<Canvas>(this.gameObject, "text");
        Text _text = Helper.FindComponentInChildWithTag<Text>(canvas.gameObject, "text");

        speechBubble = new SpeechBubble(_text);
        StartCoroutine(speechBubble.ClearText(1f));
    }

    // Update is called once per frame
    public void Update()
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
    }

    public void Say(string txt)
    {
        speechBubble.SendMessage(txt);
    }
}

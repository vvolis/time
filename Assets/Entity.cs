using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb2D;
    protected SpeechBubble speechBubble;
    public string entityName = "tmpName";

    public Transform followTarget;
    public bool followEnabled;

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

    private Vector3 lastPos;
    public void Update()
    {
        Vector3 speed = this.transform.position - lastPos;

        if (speed.magnitude > 0.0001f)
        {
            animator.SetFloat("moveX", speed.x);
            animator.SetFloat("moveY", speed.y);
            animator.SetBool("moving", true);
        }
        else
        {
            //animator.SetFloat("moveX", speed.x);
            //animator.SetFloat("moveY", speed.y);
            animator.SetBool("moving", false);
        }

        lastPos = this.transform.position;
    }

    

    public void Say(string txt)
    {
        speechBubble.SendMessage(txt);
    }


    public bool DoAction(Action action)
    {
        if (action.name == "say")
        {
            Say(action.sayText);
            DM.SetWorldState(action.resultState, true);

        } else if (action.name == "goto")
        {

            //walk to point
            //if inside the radius finish action
            followTarget = action.followTarget;
            followEnabled = true;
            Debug.Log("VV goto set on boi");

        }

        //if finished
        return true;
    }
}

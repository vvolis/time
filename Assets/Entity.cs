﻿using System.Collections;
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
        
    }

    private int refreshEveryFrames = 2;
    private int refreshCounter = 1;
    private void LateUpdate()
    {
        if (refreshCounter % refreshEveryFrames == 0)
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
        refreshCounter++;


        if (currentAction != null && currentAction.name == "goto")
        {
            if ((followTarget.position - this.transform.position).magnitude < 0.1f)
            {
                ActionComplete();
                followEnabled = false;
            } 
        }
    }

    Action currentAction = null;


    public void ActionComplete()
    {
        foreach (string state in currentAction.resultState)
        {
            DM.SetWorldState(state, true);
        }

        Debug.Log("Completed action:" + currentAction.name);


        currentAction.scene.AdvanceStory();
        currentAction = null;
    }



    public void Say(string txt)
    {
        speechBubble.SendMessage(txt);
    }

    
    public bool DoAction(Action action)
    {
        currentAction = action;
        if (action.name == "say")
        {
            Say(action.sayText);
            
            ActionComplete();


        } else if (action.name == "goto")
        {
            //walk to point
            //if inside the radius finish action
            followTarget = action.followTarget;
            followEnabled = true;
        }

        //if finished
        return true;
    }
}

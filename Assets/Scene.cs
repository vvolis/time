using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene { 
    // Start is called before the first frame update

    List<(Entity, string)> _dialogue;
    //public List<Entity> _actors;

    public Dictionary<string, Entity> _actors;

    public List<Action> story;

    public Scene()
    {
        _dialogue = new List<(Entity, string)>();
        _actors = new Dictionary<string, Entity>();
        _actors["player"] = DM.FindActor("player");
        _actors["cals1"] = DM.FindActor("cals1");
        _actors["cals2"] = DM.FindActor("cals2");
        _actors["cals3"] = DM.FindActor("cals3");


        story = new List<Action>();
        story.Add(new Action() { target = _actors["player"], name = "say", sayText = "im code sheep", conditions = { "act0" }, resultState = { "act1" } });

        story.Add(new Action() { target = _actors["cals1"], name = "say", sayText = "Ok I check it", conditions = { "act1" }, resultState = { "act2" }});
        story.Add(new Action() { target = _actors["cals1"], name = "goto", conditions = {"act2"}, resultState = { "act3" }, followTarget = _actors["player"].transform }) ;

        story.Add(new Action() { target = _actors["cals2"], name = "say", sayText = "Im lonely", conditions = { "act3" }, resultState = { "act4" } });

        story.Add(new Action() { target = _actors["cals1"], name = "say", sayText = "OK i come", conditions = { "act4" }, resultState = { "act5" } });
        story.Add(new Action() { target = _actors["cals1"], name = "goto", conditions = { "act5" }, resultState = { "act6" }, followTarget = _actors["cals2"].transform });

        story.Add(new Action() { target = _actors["cals1"], name = "say", sayText = "U came to me bro", conditions = { "act6" }, resultState = { "act0" } });

        foreach (Action act in story)
        {
            act.scene = this;
        }
 

    }

    public void Start()
    {
        //satur dialogu (kontrole laiku, atbilzu izveles un rezultatu)
        //satur events, kas liek dzekiem kko darit (piem izsauc Say)

    }

    // Update is called once per frame

    public void AdvanceStory()
    {
        Debug.Log("Story advanced");
        storyPoint++;
    }

    public int lastActionIdx = -1;

    int i = 0;
    public void Update()
    {
        if (lastActionIdx != storyPoint)
        {
            lastActionIdx = storyPoint;
            story[storyPoint % story.Count].DoAction();
            
        }

        //DM.PrintWorldState();
    }


    int storyPoint = 0;
    public void Smth()
    {
       
    }

    //Am I carrying wood, and at a stockpile? Yes: drop it off
    //Am I carrying wood? Yes: go to a stockpile
    //Am I at a tree? Yes: chop it
    //No to all above: go to a tree








}

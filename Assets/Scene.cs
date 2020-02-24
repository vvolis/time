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
        story.Add(new Action() { target = _actors["player"], name = "say", sayText = "im code sheep", resultState="act1"});

        story.Add(new Action() { target = _actors["cals1"], name = "say", sayText = "Ok I check it", resultState = "act2", followTarget = _actors["player"].transform });
        story.Add(new Action() { target = _actors["cals1"], name = "goto", resultState = "act3", followTarget = _actors["player"].transform }) ;

        story.Add(new Action() { target = _actors["cals2"], name = "say", sayText = "Im lonely", resultState = "act4" });

        story.Add(new Action() { target = _actors["cals1"], name = "say", sayText = "OK i come", resultState = "act5" });
        story.Add(new Action() { target = _actors["cals1"], name = "goto", resultState = "act6", followTarget = _actors["cals2"].transform });

        story.Add(new Action() { target = _actors["cals1"], name = "say", sayText = "U came to me bro", resultState = "act7" });

 

    }

    public void Start()
    {
        //satur dialogu (kontrole laiku, atbilzu izveles un rezultatu)
        //satur events, kas liek dzekiem kko darit (piem izsauc Say)

    }

    // Update is called once per frame

    int i = 0;
    public void Update()
    {

        bool flag = story[storyPoint % story.Count].DoAction();
        if (flag)

        storyPoint++;
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

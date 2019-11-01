using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene { 
    // Start is called before the first frame update

    List<(Entity, string)> _dialogue;
    public List<Entity> _actors;

    public Scene()
    {
        _dialogue = new List<(Entity, string)>();
        _actors = new List<Entity>();

        _actors.Add(DM.FindActor("player"));
        _actors.Add(DM.FindActor("cals3"));
        _actors.Add(DM.FindActor("cals2"));
        _actors.Add(DM.FindActor("cals1"));
    }

    public void Start()
    {
        //satur dialogu (kontrole laiku, atbilzu izveles un rezultatu)
        //satur events, kas liek dzekiem kko darit (piem izsauc Say)

        _dialogue.Add((_actors[0], "cow"));
        _dialogue.Add((_actors[1], "chickens"));
        _dialogue.Add((_actors[2], "airplane"));
        _dialogue.Add((_actors[3], "horses"));
        _dialogue.Add((_actors[3], "horses1"));
        _dialogue.Add((_actors[3], "horses2"));
        _dialogue.Add((_actors[3], "horses3"));
        _dialogue.Add((_actors[2], "smth"));
        _dialogue.Add((_actors[1], "nth"));
        _dialogue.Add((_actors[0], "around"));

    }

    // Update is called once per frame

    int i = 0;
    public void Update()
    {

        if (i == _dialogue.Count)
        {
            i = 0;
        }
        _dialogue[i].Item1.Say(_dialogue[i].Item2);
        i++;

 



    }
}

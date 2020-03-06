using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{

    //walk
    //say
    //interact
    public string name;
    public Transform walkPosition;

    public string sayText;
    public Entity target;
    public Transform followTarget;
    public Scene scene;

    //result map
    public List<string> conditions = new List<string>() { "" };
    public List<string> resultState = new List<string>() { "" };



    public bool DoAction()
    {
        
        return target.DoAction(this);


        //then based on result set a flag?

    }
}

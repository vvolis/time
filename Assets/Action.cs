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

    //result map

    public string resultState = "";

    public bool DoAction()
    {
        
        return target.DoAction(this);


        //then based on result set a flag?

    }
}

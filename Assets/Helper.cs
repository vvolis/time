using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    // Start is called before the first frame update

        public static T FindComponentInChildWithTag<T>(this GameObject parent, string tag) where T : Component
        {
            Transform t = parent.transform;
            foreach (Transform tr in t)
            {
                Debug.Log("Checking " + tr.tag);
                if (tr.tag == tag)
                {
                    
                    return tr.GetComponent<T>();
                }
            }
            return null;
        }
    
}

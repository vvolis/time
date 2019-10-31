using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class DM : MonoBehaviour
{
    private static DM _instance;
    public static DM Instance { get { return _instance; } }

    public Text textScreen;

    private int i = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.Log("Duplicate DM found");
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ClearText(1f));
    }


    IEnumerator ClearText(float time)
    {
        while (true) {
            if (_instance.msgTime < System.DateTime.Now)
            {
                SendMessage("...");
            } 
            yield return new WaitForSeconds(time);
        }
    }

    private System.DateTime msgTime;

    public static void SendMessage(string txt)
    {
        _instance.msgTime = System.DateTime.Now.AddSeconds(2);
        _instance.textScreen.text = txt;
    }

    // Update is called once per frame
    void Update()
    {

        //textScreen.text = i.ToString();
        i++;
    }







}



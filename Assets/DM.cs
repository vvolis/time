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

        _instance.actors = new Dictionary<string, Entity>();
    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ClearText(1f));
       




    }

    private Dictionary<string, Entity> actors;
    public static void RegisterPlayer(string name, Entity self)
    {
        Debug.Log("Registering " + name);
        _instance.actors.Add(name, self);

    }


    IEnumerator ClearText(float time)
    {
        while (true) {
            if (Instance.msgTime < System.DateTime.Now)
            {
                SendMessage("...");
            } 
            yield return new WaitForSeconds(time);
        }
    }

    private System.DateTime msgTime;

    public static void SendMessage(string txt)
    {
        //Instance.msgTime = System.DateTime.Now.AddSeconds(2);
        //Instance.textScreen.text = txt;
    }

    // Update is called once per frame

    bool sceneInitiated = false;
    Scene scene;
    float timeLeft = 0f;
    void Update()
    {

        timeLeft += Time.deltaTime;
        if (timeLeft > 1f && sceneInitiated)
        {
            scene.Update();
            timeLeft = 0f;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!sceneInitiated)
            {
                scene = new Scene();
                //bug.Log("Scene created");

                scene._actors.Add(actors["player"]);
                scene._actors.Add(actors["cals1"]);
                scene._actors.Add(actors["cals2"]);
                scene._actors.Add(actors["cals1"]);
                //bug.Log("Scene actors added");

                scene.Start();
               //ebug.Log("Scene started");
                sceneInitiated = true;
            }
            

            scene.Update();
        }

        //textScreen.text = i.ToString();
        i++;
    }



    public static Entity FindActor(string name)
    {
        return Instance.actors[name];
    }

    public Dictionary<string, bool> worldState = new Dictionary<string, bool>();

    public static void SetWorldState(string key, bool value)
    {
        Instance.worldState[key] = value;
    }

    public static bool GetWorldState(string key)
    {
        return Instance.worldState[key];
    }

    public static void PrintWorldState()
    {
        foreach (KeyValuePair<string, bool> pair in Instance.worldState)
        {
            Debug.Log(pair.Key + ":" + pair.Value);
        }
    }


}



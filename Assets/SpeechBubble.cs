using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble 
{


    private System.DateTime _msgTime;
    public Text _textScreen;

    public SpeechBubble(Text textScreen)
    {
        _textScreen = textScreen;
    }

    public IEnumerator ClearText(float time)
    {
        while (true)
        {
            if (_msgTime < System.DateTime.Now)
            {
                SendMessage("...");
            }
            yield return new WaitForSeconds(time);
        }
    }

    public void SendMessage(string txt)
    {
        _msgTime = System.DateTime.Now.AddSeconds(2);
        _textScreen.text = txt;
    }
}

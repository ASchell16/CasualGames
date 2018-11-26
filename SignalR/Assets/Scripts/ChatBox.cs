using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour {
    public GameObject content;
    public GameObject txtMessage;
    
	void Start ()
    {
        

    }
	
    public void OnInput(string message)
    {
        txtMessage.GetComponent<Text>().text = message;
        Instantiate(txtMessage, content.transform);
        Console.WriteLine(message);
    }
}

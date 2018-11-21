using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour {

    string Message;
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void OnInput(string message)
    {
        Message = message;
        Console.WriteLine(Message);
    }
}

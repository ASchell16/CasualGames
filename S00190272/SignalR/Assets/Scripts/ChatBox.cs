using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour {
	public List<string> listMessage = new List<string>();
    public GameObject content;
    public GameObject txtMessage;
	public InputField input;
	public SignalRController signal;
	Leave leave;
	public string txt;
	
	void Update()
	{		
		foreach (var m in listMessage)
		{
					
			AddMessage(m);
		}
		listMessage.Clear();
	}
	public void SendMessage()
	{
		signal.OnSendMessage(input.text);		
	}
	public void AddMessage(string m)
	{
		txtMessage.GetComponent<Text>().text = m;
		Instantiate(txtMessage, content.transform);
	}

	public void OnPlayerJoined(string username)
	{
		listMessage.Add(username + " Has Joined!");		
	}  

	public void RecievedMessage(string username, string message)
	{
		listMessage.Add(username + " Has Said " + message);
	}

	public void PlayerLeft(string username)
	{
		listMessage.Add(username + " Has Left!"); 
	}
	
}

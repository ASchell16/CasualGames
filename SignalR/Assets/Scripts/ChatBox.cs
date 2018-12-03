using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour {
    public GameObject content;
    public GameObject txtMessage;
	public InputField input;
	public SignalRController signal;
	Leave leave;

	public void SendMessage()
	{
		string txt = input.text;
		signal.OnSendMessage(txt);
		
	}
	public void OnPlayerJoined(string username)
	{
		txtMessage.GetComponent<Text>().text = username + " Has Joined!";
		Instantiate(txtMessage, content.transform);
	}  

	public void RecievedMessage(string username, string message)
	{
		txtMessage.GetComponent<Text>().text = username + " Has Said " + message;
		Instantiate(txtMessage, content.transform);
	}

	public void PlayerLeft(string username)
	{
		txtMessage.GetComponent<Text>().text = username + " Has Left";
		Instantiate(txtMessage, content.transform);
		leave.Left();
	}
	
}

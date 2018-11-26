using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalRController : MonoBehaviour {

    public string endpoint = "http://localhost:2490/";
    public string hubName = "ChatHub";
    public string usersName = "Alex";
    bool isConnected = false;
    HubConnection connection;
    IHubProxy proxy;
    public ChatBox chat;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
        ConnectToHub();

    }

    void OnApplicationQuit()
    {
        isConnected = false;
    }

    
    
    public void ConnectToHub()
    {
        if (!string.IsNullOrEmpty(endpoint) && !string.IsNullOrEmpty(hubName))
        {
            connection = new HubConnection(endpoint);
            proxy = connection.CreateHubProxy(hubName);
            // connect to the player joined Hub and run the player joined method
            proxy.On("PlayerJoined", new Action<string>(PlayerJoined));
            proxy.On("RecieveMessage", new Action<string, string>(MessageRecieved));
            proxy.On("PlayerLeft", new Action<string>(PlayerLeft));

            connection.Start().Wait();// Waits For task to complete
            isConnected = true;
            
        }
    }

    public void JoinChat(string username)
    {
        if (isConnected)
        {
            proxy.Invoke("Join", username);
        }
    }

    public void LeftChat()
    {
        if (!isConnected)
        {
            proxy.Invoke("Leave", usersName);
        }
    }

    public void onSendMessage(string message)
    {
        if (isConnected)
        {
            proxy.Invoke("SendMessageToOthers", usersName, message);
        }
    }


    public void PlayerJoined(string username)
    {
        Debug.Log(username + "Has Joined");
    }

    public void PlayerLeft(string username)
    {
        Debug.Log(username + "Has Left");
    }
    public void MessageRecieved(string username, string message)
    {
        Debug.Log(username + "Has Said" + message);
    }
}

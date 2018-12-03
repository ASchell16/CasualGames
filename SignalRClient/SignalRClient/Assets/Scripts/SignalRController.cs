using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AspNet.SignalR.Client;
using System;

public delegate void PlayerDataDelgate(PlayerData data);
public delegate void ServerConnectionDelegate();
public class SignalRController : MonoBehaviour
{
    public static event PlayerDataDelgate OnPlayerDataRecieved;
    public static event ServerConnectionDelegate OnConnectionToServer;

    public string endPoint = "http://localhost:8909/";
    public string hubName = "GameHub";

    static IHubProxy proxy;
    public static bool isConnected = false;
    HubConnection connection;

    // Use this for initialization
    void Awake()
    {
        ConnectToHub();
    }

    void ConnectToHub()
    {
        if (!string.IsNullOrEmpty(endPoint) && !string.IsNullOrEmpty(hubName))
        {
            connection = new HubConnection(endPoint);
            proxy = connection.CreateHubProxy(hubName);
            proxy.On("RecievePlayerData", new Action<PlayerData>(OnRecievePlayerData));
            connection.Start().Wait();
            isConnected = true;
            OnConnectionToServer?.Invoke();
            Debug.Log("Connection");
        }
    }

    void OnRecievePlayerData(PlayerData data)
    {
        OnPlayerDataRecieved?.Invoke(data);
    }
    public static void SendPlayerData(PlayerData data)
    {
        if (isConnected)
        {
            proxy.Invoke("UpdatePlayer", data);
        }
    }
    private void OnApplicationQuit()
    {
        if (isConnected)
        {
            connection.Stop();
        }
    }
}


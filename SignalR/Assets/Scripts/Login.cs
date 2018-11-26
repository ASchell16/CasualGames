using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {


    public SignalRController signal;
    
	// Use this for initialization
	void Start ()
    {
        
	}

    public void OnInput(string Username)
    {
        string user = signal.usersName;
        
        if (Username == user)
        {
            signal.JoinChat(Username);
            SceneManager.LoadScene(1);
        }
    }
}

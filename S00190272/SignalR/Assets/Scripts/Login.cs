using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {


    public SignalRController signal;
	public Button btnJoin;
	public InputField userInput;
	public string Username;
   

    public void OnInput()
	{ 
			signal.JoinChat(userInput.text);
		
    }
}

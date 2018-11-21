using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {


    public SignalRController signal;
    Text loginText;
	// Use this for initialization
	void Start ()
    {
        
	}

    public void OnInput(string Username)
    {     

        string Usersname = signal.usersName;
        //loginText.text = Username;
        if (Username == Usersname)
        {
            Debug.Log("Input Recieved");
            signal.JoinChat(Username);
            SceneManager.LoadScene(1);
        }
    }
}

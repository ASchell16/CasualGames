using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : MonoBehaviour
{
	public SignalRController signal;
	public void LogOff()
	{
		if (signal.isConnected)
		{
			signal.OnApplicationQuit();
			signal.LeftChat();
		}
		
	}
	public void Left()
	{
		Application.Quit();
	}
}

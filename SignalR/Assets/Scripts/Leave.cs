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
			signal.LeftChat();			
		}
		
	}
	public void Left()
	{
		signal.OnApplicationQuit();
	}
}

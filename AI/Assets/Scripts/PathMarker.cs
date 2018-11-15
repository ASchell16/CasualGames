using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMarker : MonoBehaviour {

    // Use this for initialization
    public PathMarker nextMarker;
    
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(this.transform.position, nextMarker.transform.position, Color.green);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshObstacle))]
[RequireComponent(typeof(Rigidbody))]
public class DoorController : MonoBehaviour {

    NavMeshObstacle obstacle;
    Rigidbody body;
    public bool isLocked;
	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody>();
        obstacle = GetComponent<NavMeshObstacle>();
        if (isLocked)
            Lock();
        else
            Unlock();
	}
    private void Lock()
    {
        obstacle.carving = true;
        body.isKinematic = true;
        isLocked = true;
    }
    private void Unlock()
    {
        obstacle.carving = false;
        body.isKinematic = false;
        isLocked = false;
    }


}

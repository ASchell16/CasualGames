using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollowPath : MonoBehaviour {

    public PathMarker Target;
    NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        
        agent = GetComponent<NavMeshAgent>();

        MoveTo();
        
    }
    void MoveTo()
    {
        agent.destination = Target.transform.position;
    }
	// Update is called once per frame
	void Update ()
    {
        
	}
    
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "PathMarker")
        { 
            Target = other.gameObject.GetComponent<PathMarker>().nextMarker;
            MoveTo();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIFollowCursor : MonoBehaviour {

    // Use this for initialization
    NavMeshAgent agent;
    RaycastHit result;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out result, 1000)) ;
            {
                if (result.collider != null)
                    MoveTo(result.point);
            }
           
        }
        DrawPath();
	}

    void DrawPath()
    {
        if (agent.path.corners.Length > 0)
        {
            for (int i = 0; i < agent.path.corners.Length; i++)
                if (!(i + 1 >= agent.path.corners.Length))
                {
                    Debug.DrawLine(agent.path.corners[i],
                                   agent.path.corners[i + 1],
                                   Color.red);
                }
        }
    }

    public void MoveTo(Vector3 destination)
    {
        agent.destination = destination;
    }
}

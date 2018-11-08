using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Tracker : MonoBehaviour {

    // Use this for initialization
    public Transform Track;
    public bool DrawLine;
    public int Distance = 100;
    LineRenderer lineRenderer;
    RaycastHit result;
    int trackingDistance = 10;
    public bool usetrackingDistance = false;

    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Track);

        if (usetrackingDistance && Vector3.Distance(transform.position, Track.position) <= trackingDistance) {
            if (DrawLine)
            {
                lineRenderer.SetPosition(0, transform.position);
                if (Physics.Raycast(transform.position, transform.forward, out result, Distance))
                {
                    if (result.collider.tag != "Player")
                    {
                        lineRenderer.SetPosition(1, result.point);
                    }
                    else
                    {
                        lineRenderer.SetPosition(1, Track.position);
                    }
                }


            }
        }

	}

    private void OnDrawGizmos()
    {
        if (gameObject.tag != "MainCamera")
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, trackingDistance);
        }
    }
}

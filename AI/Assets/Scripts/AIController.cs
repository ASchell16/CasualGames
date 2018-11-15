using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public enum AIStates { Patrolling, MovingToTarget, Attacking }

    public AIStates states;
    NavMeshAgent agent;
    public PathMarker target;
    public GameObject Player;
    public RangeInt distFromPlayerX;
    public RangeInt distFromPlayerZ;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        

    }
    void MoveTo()
    {
        agent.destination = target.transform.position;
    }
    void FollowPlayer(Vector3 destination)
    {
        agent.destination = destination - new Vector3(distFromPlayerX,0,distFromPlayerZ);
        
    }
   

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "PathMarker")
        {
            target = other.gameObject.GetComponent<PathMarker>().nextMarker;
            MoveTo();
        }
             
    } 

    private void Update()
    {
        if (states == AIStates.Patrolling)
        {
            MoveTo();
        }
        if (states == AIStates.MovingToTarget)
        {
            FollowPlayer(Player.transform.position);
        }
        if (states == AIStates.Attacking)
        {
            FollowPlayer(Player.transform.position);
        }
    }
}

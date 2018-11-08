using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    Rigidbody body;
    public float Jump = 1;
    public float Rotation = 1f;
    public float Move = .5f;
    float horInput;
    float vertInput;
    bool canJump;
    Vector3 force = Vector3.zero;

	void Start ()
    {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        horInput = Input.GetAxis("Horizontal") * Move;
        vertInput = Input.GetAxis("Vertical") * Move;
        body.AddForce(horInput, 0, vertInput);
        if (Input.GetKeyUp(KeyCode.Space) && canJump)
        {
            body.AddForce(0, Jump, 0, ForceMode.Impulse);
            canJump = false;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, Rotation, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -Rotation, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, Move);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0,-Move);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Move, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Move, 0, 0);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

}

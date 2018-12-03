using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerComponent : MonoBehaviour {

    Rigidbody body;
    public float MoveSpeed = 10;
    public GameObject Shield;
    public GameObject Bullet;
    public Transform BulletSpawn;

    public PlayerData data = new PlayerData();
    public bool isOnline = false;
	void Start ()
    {
        body = GetComponent<Rigidbody>();
        SignalRController.OnConnectionToServer += SignalRController_OnConnectionToServer;
	}

    private void SignalRController_OnConnectionToServer()
    {
       // isOnline = true;
    }

    void Update ()
    {
        data.horizontal = Input.GetAxis("Horizontal");
        data.vertical = Input.GetAxis("Vertical");
        data.state = PlayerState.None;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            data.state = PlayerState.Shield;
        }
        else if (Input.GetMouseButton(0))
        {
            data.state = PlayerState.Shoot;
        }

        if (SignalRController.isConnected)
        {
            SignalRController.SendPlayerData(data);
        }

                   // processing input
            if (data.state == PlayerState.Shield)
            {
                Shield.SetActive(true);
            }
            else
            {
                Shield.SetActive(false);
            }

            if (data.state == PlayerState.Shoot)
            {
                var bulletBody = Instantiate(Bullet,
                                             BulletSpawn.position,
                                             Quaternion.identity);
                bulletBody.GetComponent<Rigidbody>().velocity = transform.forward * 10;

            }
            body.AddForce(data.horizontal * MoveSpeed, 0, data.vertical * MoveSpeed);
        
    }
}

[Serializable]
public class PlayerData
{
    public PlayerState state;
    public float vertical;
    public float horizontal;
}

[Serializable]
public enum PlayerState
{
    None = 0,
    Shield = 1,
    Shoot = 2  
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerController : MonoBehaviour {

    Rigidbody body;
    public float MoveSpeed = 10;
    public GameObject Shield;
    public GameObject Bullet;
    public Transform BulletSpawn;

    public PlayerData data = new PlayerData();

    void Start()
    {
        body = GetComponent<Rigidbody>();
        SignalRController.OnPlayerDataRecieved += SignalRController_OnPlayerDataRecieved;
    }

    private void SignalRController_OnPlayerDataRecieved(PlayerData data)
    {
       this.data = data;
    }

    void Update()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EmptyDelegate();
public delegate void GameObjectDelegate(GameObject sender);


[RequireComponent(typeof(AudioSource))]
public class AchievementManager : MonoBehaviour
{
    public AudioSource audio;
    public GameObject achieveCont;
    public Canvas canvas;
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnlockAchieve(new AchievementClass
            {
                achieveName = "test",
                achieveDes = "Jumped",
                
            });
        }
    }

    public void UnlockAchieve(AchievementClass Achieve)
    {
       // audio.Play();
        var control = Instantiate(achieveCont, canvas.transform);
        

    }

}

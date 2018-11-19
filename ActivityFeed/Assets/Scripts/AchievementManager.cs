using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public delegate void EmptyDelegate();
public delegate void GameObjectDelegate(GameObject sender);


[RequireComponent(typeof(AudioSource))]
public class AchievementManager : MonoBehaviour
{
    public AudioSource audio;
    public GameObject achieveCont;
    public Canvas canvas;
    public AchievementData Data;
    public List<AchievementClass> Achievements;

    void Start()
    {
        Debug.Log("Method Working");
        audio = GetComponent<AudioSource>();

        if (!FileHelper.DoesAchievementDataExist())
        {
            FileHelper.CreateAchievementData();
        }

        Data = FileHelper.LoadAchievementData();

        Achievements.Add(new AchievementClass
        {
            achieveName = "Jumper",
            achieveDes = "Jump",
            ActionName = "CheckJumps",
            Image = "achieve"
        });

        var player = GameObject.Find("Player").GetComponent<PlayerController>();
        player.OnJump += Player_OnJump;
    }

    private void Player_OnJump()
    {
       
        Data.jumps++;
    }


    private void MapActiontoAchieve(AchievementClass ach)
    {
        if (!string.IsNullOrEmpty(ach.ActionName))
        {
            MethodInfo method = GetType().GetMethod(ach.ActionName);
            if(method != null )
            ach.Action = (Action<AchievementClass>)Delegate.CreateDelegate(typeof(Action<AchievementClass>), this, method);

        }
    }

    public void CheckJumps(AchievementClass ach)
    {
        if (Data.jumps >= 10)
        {
            ach.isComplete = true;
            UnlockAchieve(ach);
        }
    }

    private void Update()
    {
        foreach (var ach in Achievements)
        {
            if (!ach.isComplete)
            {
                ach.Action.Invoke(ach);
            }
        }

    }

    public void UnlockAchieve(AchievementClass Achieve)
    {
       // audio.Play();
        var control = Instantiate(achieveCont, canvas.transform);
        control.GetComponent<AchieveController>().InitAchieve(Achieve);

    }
    private void OnApplicationQuit()
    {
        FileHelper.SaveAchievementData(Data);
    }

}

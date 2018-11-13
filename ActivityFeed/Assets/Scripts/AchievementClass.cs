using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AchievementClass
{
    public int ID;
    public string achieveName;
    public string achieveDes;
    public int rGXP;
    public int rCurr;
    public string Image;
    public bool isSecre;
    public bool isComplete;
    public string ActionName; // name of method to check achievement
    public Action<AchievementClass> Action; 
           
}
[Serializable]
public class AchievementData
{
    public int jumps;
    public float distanceTravelled;
    public int Healing;
}
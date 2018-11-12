using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AchievementClass
{
    public int ID { get; set; }
    public string achieveName { get; set; }
    public string achieveDes { get; set; }
    public int rGXP { get; set; }
    public int rCurr { get; set; }
    public string Image { get; set; }
    public bool isSecret { get; set; }
    public bool isComplete { get; set; }
           
}

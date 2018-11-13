using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileHelper : MonoBehaviour
{
    public static void SaveJsonToDisk(string filename, string json)
    {
        File.WriteAllText(Application.persistentDataPath + "\\" + filename, json);
    }

    public static string LoadJsonFromDisk(string filename)
    {
        return File.ReadAllText(Application.persistentDataPath + "\\" + filename);
    }

    public static void CreateAchievementData()
    {
        string json = JsonUtility.ToJson(new AchievementData());
        SaveJsonToDisk("AchievementData", json);

    }

    public static AchievementData LoadAchievementData()
    {
        string json = LoadJsonFromDisk("AchievementData.json");
        return JsonUtility.FromJson<AchievementData>(json);

    }
    public static void SaveAchievementData(AchievementData data)
    {
        string json = JsonUtility.ToJson(data);
        SaveJsonToDisk("AchievementData", json);

    }

    public static bool DoesAchievementDataExist()
    {
        return File.Exists(Application.persistentDataPath + "\\AchievementData.json");
    }
}

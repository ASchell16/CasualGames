using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using UnityEngine;
using System.IO;

public class ListWrapper<T>
{
    public List<T> items;

}
public class ApiHelper
{
    public static string ApiAddress = "http://localhost:2247/api/";
    public static string ItemsController = "items";
    public static string GetjsonFromApi(string controllerName)
    {
        string json = string.Empty;
        using (WebClient client = new WebClient())
        {
            json = client.DownloadString(ApiAddress + controllerName);
        }

        return json;
            
    }

    public static List<Models> GetShopItems()
    {
        string json = GetjsonFromApi(ItemsController);
        json = ConvertJsonArrayToWrapperString(json);

        FileHelper.SaveJsonToDisk("shop_items.json", json);

        return JsonUtility.FromJson<ListWrapper<Models>>(json).items;
    }
    private static string ConvertJsonArrayToWrapperString(string json)
    {
        return "{\"items\":" + json + "}";
    }
    public static bool HasInternetConnection()
    {
        try
        {
            // try and communicate with any known website/service
            using (WebClient client = new WebClient())
            {
                client.OpenRead("http://www.google.com");
            }
            return true;
        }
        catch
        {
            return false;
        }
    }


}
public class FileHelper
{
    public static void SaveJsonToDisk(string filename, string json)
    {
        File.WriteAllText(Application.persistentDataPath + "\\" + filename, json);
    }

    public static void LoadJsonFromDisk(string filename)
    {
        File.ReadAllText(Application.persistentDataPath + "\\" + filename);
    }
}


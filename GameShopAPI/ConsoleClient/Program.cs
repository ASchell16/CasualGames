using CSWeek3._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "http://localhost:2247/api/";
            string apiController = "items";

            List<Item> downloadedItems = new List<Item>();

            string jsonData;

            Console.WriteLine("Press Enter to Begin");
            Console.ReadLine();
            using (WebClient client = new WebClient())
            {
                jsonData = client.DownloadString(address + apiController);

            }
            downloadedItems = JsonConvert.DeserializeObject<List<Item>>(jsonData);

            foreach (var item in downloadedItems)
            {
                Console.WriteLine(item.Name + " : " + item.Category);
            }
            using (StreamWriter sw = File.CreateText("storeitems.json"))
            {
                sw.Write(jsonData);

            }
            Console.WriteLine(jsonData);
            Console.ReadLine();
        }
    }
}

using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static string endpoint = "http://localhost:2490/";
        static string hubName = "TestHub";
        static string usersName;
        static HubConnection connection;
        static IHubProxy proxy;

        static void Main(string[] args)
        {
            ConnectToHub();
            bool StayConnected = true;
            Console.WriteLine("Enter a Name");
            usersName = Console.ReadLine();

            while (StayConnected)
            {

                Console.WriteLine("Type Your Message or Type -1 to Exit");
               
                string message = Console.ReadLine();

                if (message == "-1")
                {
                    StayConnected = false;
                }
                else
                {
                    proxy.Invoke("TestMessage", usersName, message);
                }
            }

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }

        public async static void ConnectToHub()
        {
            if (!string.IsNullOrEmpty(endpoint) && !string.IsNullOrEmpty(hubName))
            {
                connection = new HubConnection(endpoint);
                proxy = connection.CreateHubProxy(hubName);


                // setup Methods and Link

                // Has to be the same call as the hub
                proxy.On("RecieveMessage", new Action<string, string>(OnRecieveMessage));

                //Connect to server
                connection.Received += Connection_Recieved;
                await connection.Start();// Waits For task to complete
            }
        }
        private static void Connection_Recieved(string obj)
        {
            Console.WriteLine("Connected");
        }
        // Can be whatevername as long as proxy calls it
        public static void OnRecieveMessage(string sender, string message)
        {
            Console.WriteLine("{0} says {1}", sender, message);
        }

    }
}

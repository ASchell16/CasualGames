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
        static string endpoint = "http://localhost:8909/";
        static string hubName = "TestHub";

        static void Main(string[] args)
        {
            ConnectToHub();

            bool stayConnected = true;

            while (stayConnected)
            {
                Console.WriteLine("Enter your message:");
                string message = Console.ReadLine();

                if (message == "-1")
                {
                    stayConnected = false;
                }
                else
                {
                    proxy.Invoke("TestMessage", "Neil", message);
                }
            }

            Console.WriteLine("Press Enter to Exit.");
            Console.ReadLine();
        }


        static HubConnection connection;
        static IHubProxy proxy;

        public async static void ConnectToHub()
        {
            if (!string.IsNullOrEmpty(endpoint) && !string.IsNullOrEmpty(hubName))
            {
                connection = new HubConnection(endpoint);
                proxy = connection.CreateHubProxy(hubName);

                //setup methods and link
                proxy.On("RecieveMessage", new Action<string, string>(OnRecieveMessage));

                //connect to server
                connection.Received += Connection_Received;
                await connection.Start();//waits for the task to complete
            }
        }

        private static void Connection_Received(string obj)
        {
            
        }

        public static void OnRecieveMessage(string sender, string message)
        {
            Console.WriteLine("{0} says, {1}", sender, message);
        }
    }
}

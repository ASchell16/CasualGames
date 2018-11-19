using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 


namespace SignalRServer.Hubs
{
    // A hub only holds the methods that talk to the client and the game

    [HubName("TestHub")]
    public class TestHub : Hub
    {
        public void TestMessage(string sender, string message)
        {
            Clients.All.RecieveMessage(sender, message);
        }
    }
}
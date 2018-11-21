using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 


namespace SignalRServer.Hubs
{
    // A hub only holds the methods that talk to the client and the game

    [HubName("ChatHub")]
    public class TestHub : Hub
    {
        public void SendMessage(string sender, string message)
        {
            Clients.All.RecieveMessage(sender, message);
        }
        public void SendMessageToOthers(string sender, string message)
        {
            Clients.Others.RecieveMessage(sender, message);
        }
        public void Join(string user)
        {
            Clients.Others().PlayerJoined(user);
        }

        public void Leave(string user)
        {
            Clients.Others().PlayerLeft(user);
        }
     
    }
}
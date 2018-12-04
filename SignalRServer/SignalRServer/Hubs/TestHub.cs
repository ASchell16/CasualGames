using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRServer.Models;
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
            //if(DatabaseHelper.FindPlayer(sender) != null)
            //{
				Clients.All.RecieveMessage(sender, message);

                //DatabaseHelper.AddPlayerMessage(new Models.PlayerMessage()
                //{
                 //   Username = sender,
                  //  MessageSent = message,
                   // DateSent = DateTime.UtcNow,
                //});
            //}
        }
        public void SendMessageToOthers(string sender, string message)
        {
           // if(DatabaseHelper.FindPlayer(sender) != null)
                Clients.All.RecieveMessage(sender, message);
        }
        public void Join(string user)
        {			
           //if (DatabaseHelper.FindPlayer(user) != null)
                Clients.Others.PlayerJoined(user);
        }

        public void Leave(string user)
        {
           // if (DatabaseHelper.FindPlayer(user) != null)
                Clients.Others.PlayerLeft(user);
        }
		
    }
}
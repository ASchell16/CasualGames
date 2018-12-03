using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRServer.Hubs
{
    [HubName("GameHub")]
    public class TestHub : Hub
    {
        public void UpdatePlayer(PlayerData data)
        {
            Clients.All.RecievePlayerData(data);
        }
    }

    public class PlayerData
    {
        public PlayerState state { get; set; }
        public float vertical { get; set; }
        public float horizontal { get; set; }
    }

    
    public enum PlayerState
    {
        None = 0,
        Shield = 1,
        Shoot = 2
    }
}
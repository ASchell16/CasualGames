﻿using SignalRServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRServer.Hubs
{
    public static class DatabaseHelper
    {
        public static GameContext CreateContext()
        {
            return new GameContext();
        }
        public static Player FindPlayer(string username)
        {
            using (var context = CreateContext())
            {
                return context.Players.Find(username);
            }

        }

        public static List<PlayerMessage> FindAllPlayerMessages(string username)
        {
            using (var context = CreateContext())
            {
                return context.Messages.Where(m => m.Username == username).ToList();
            }
        }
        public static void AddPlayerMessage(PlayerMessage message)
        {
            if (message != null)
            {
                using (var context = CreateContext())
                {
                    context.Messages.Add(message);
                    context.SaveChanges();
                }

            }
            else
            {
                throw new Exception("No Message");
            }
        }

		
    }
}
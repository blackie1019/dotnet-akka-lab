using System;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Demo.AkkaNet.Gambling.WebApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task sendMsg(string user, string message)
        {
            Console.WriteLine($"{user} said: {message}");
            await Clients.All.SendAsync("updateMsg", user, message);
        }
    }
}
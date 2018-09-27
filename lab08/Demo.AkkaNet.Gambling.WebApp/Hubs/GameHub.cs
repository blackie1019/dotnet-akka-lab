using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using Demo.AkkaNet.Gambling.Core.ValueObjects;
using Demo.AkkaNet.Gambling.WebApp.Controllers;
using Microsoft.AspNetCore.SignalR;

namespace Demo.AkkaNet.Gambling.WebApp.Hubs
{
    public class GameHub : Hub
    {
        public async Task updateGames(IEnumerable<MarketlineVO> data)
        {
            Console.WriteLine("updateGames trigger");
            await Clients.All.SendAsync("updateGames", data);
        }
    }
}
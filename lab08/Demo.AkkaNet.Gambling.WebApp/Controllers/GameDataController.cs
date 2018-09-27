using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.AkkaNet.Gambling.Core.Commands;
using Demo.AkkaNet.Gambling.Core.Utilities;
using Demo.AkkaNet.Gambling.Core.ValueObjects;
using Demo.AkkaNet.Gambling.WebApp.Actors;
using Demo.AkkaNet.Gambling.WebApp.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Demo.AkkaNet.Gambling.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class GameDataController : Controller
    {
        private IHubContext<GameHub> _singalRHub;
        private IApiGameActorInstance _apiGameActorInstance;
        
        public GameDataController(IHubContext<GameHub> hubContext,IApiGameActorInstance apiGameActorInstance)
        {
            _singalRHub = hubContext;
            _apiGameActorInstance = apiGameActorInstance;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<MarketlineVO>> SelectionsOdds()
        {

            var data = GameHelper.GenerateMaketlines();
            await _singalRHub.Clients.All.SendAsync("updateGames", data);
            return await _apiGameActorInstance.Reply(new GameDataUpdateMessage(DateTime.Now,data));
        }
    }
}
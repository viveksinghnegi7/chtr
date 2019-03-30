using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chtr.server.Contracts;
using chtr.server.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace chtr.server.Controllers
{
    [Produces("application/json")]
    [Route("api/Chat")]
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub, ITypedHubClient> _hubContext;

        public ChatController(IHubContext<ChatHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("say")]
        public async Task SayAsync([FromBody] Message message)
        {
            await _hubContext.Clients.All.Say(message);
        }
    }
}
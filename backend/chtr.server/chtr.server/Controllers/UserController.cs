using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chtr.server.Contracts;
using chtr.server.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace chtr.server.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        IHubContext<ChatHub, ITypedHubClient> _hubContext;
        private readonly ChatHub _chatHub = new ChatHub();

        public UserController(IUserRepository userRepository, IHubContext<ChatHub, ITypedHubClient> hubContext)
        {
            _userRepository = userRepository;
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("register")]
        public async Task RegisterUserAsync([FromBody] string userName)
        {
            await _hubContext.Clients.All.UserJoined(userName);
        }

        [HttpGet]
        [Route("all")]
        public async Task<string[]> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

    }
}

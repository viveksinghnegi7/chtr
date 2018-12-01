using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chtr.server.Contracts;
using chtr.server.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace chtr.server.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IHubContext<ChatHub> _chatHub;

        public UserController(IUserRepository userRepository, IHubContext<ChatHub> chatHub)
        {
            _userRepository = userRepository;
            _chatHub = chatHub;
        }

        [HttpPost]
        [Route("register")]
        public async Task RegisterUserAsync([FromBody] string userName)
        {
            await _chatHub.Clients.All.SendAsync("UserJoined", userName);
        }

        [HttpGet]
        [Route("all")]
        public async Task<string[]> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chtr.server.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace chtr.server.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<string[]> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

    }
}

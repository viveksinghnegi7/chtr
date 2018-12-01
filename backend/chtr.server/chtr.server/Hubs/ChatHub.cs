using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace chtr.server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task UserJoined(string userName)
        {
           await Clients.All.SendAsync("NewUserJoined", userName);
        }
    }
}

using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace chtr.server.Hubs
{
    public class ChatHub : Hub
    {
        public Task NotifyNewUser(string userName)
        {
            return Clients.All.SendAsync("NotifyNewUser", userName);
        }
    }
}

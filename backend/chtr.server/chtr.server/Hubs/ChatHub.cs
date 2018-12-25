using chtr.server.Contracts;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace chtr.server.Hubs
{
    public class ChatHub : Hub<ITypedHubClient>
    {
    }
}

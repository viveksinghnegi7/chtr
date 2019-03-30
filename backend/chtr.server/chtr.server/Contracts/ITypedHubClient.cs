using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chtr.server.Contracts
{
    public interface ITypedHubClient
    {
        Task UserJoined(string userName);
        Task Say(Message message);
    }
}

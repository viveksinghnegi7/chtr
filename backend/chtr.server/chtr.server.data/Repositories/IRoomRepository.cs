using chtr.server.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.data.Infrastructure
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetRooms();
        Room GetRoom(Guid roomId);
    }
}

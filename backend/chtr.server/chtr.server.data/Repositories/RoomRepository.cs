using System;
using System.Collections.Generic;
using System.Text;
using chtr.server.data.Entities;

namespace chtr.server.data.Infrastructure
{
    public class RoomRepository : IRoomRepository
    {
        public Room GetRoom(Guid roomId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}

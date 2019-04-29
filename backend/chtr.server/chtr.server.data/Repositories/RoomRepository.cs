using System;
using System.Collections.Generic;
using System.Text;
using chtr.server.data.Entities;
using System.Linq;

namespace chtr.server.data.Infrastructure
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ChtrDbContext _dbContext;

        public RoomRepository(ChtrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Room GetRoom(Guid roomId)
        {
            return _dbContext.Rooms.FirstOrDefault(p => p.Id == roomId);
        }

        public IEnumerable<Room> GetRooms()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using chtr.server.data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return _dbContext.Rooms.Include(r => r.UserRoom)
                                   .ThenInclude(u => u.User)
                                   .Where(p => p.Id == roomId).FirstOrDefault();
        }

        public IEnumerable<Room> GetRooms()
        {
            return _dbContext.Rooms.Include(r => r.UserRoom)
                                    .ThenInclude(u => u.User);
        }
    }
}

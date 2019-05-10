using System;
using chtr.server.data.Entities;
using System.Linq;
using System.Collections.Generic;

namespace chtr.server.data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChtrDbContext _context;

        public UserRepository(ChtrDbContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetUser(Guid id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<User> GetUsersInRoom(Guid id)
        {
            var rooms = _context.Rooms.Where(p => p.Id == id).ToList();
            return rooms.SelectMany(p => p.UserRoom.Select(r => r.User));
        }
    }
}

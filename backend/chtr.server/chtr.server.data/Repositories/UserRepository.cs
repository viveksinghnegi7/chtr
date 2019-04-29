using System;
using chtr.server.data.Entities;
using System.Linq;

namespace chtr.server.data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChtrDbContext _context;

        public UserRepository(ChtrDbContext context)
        {
            _context = context;
        }

        public User GetUser(Guid id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }
    }
}

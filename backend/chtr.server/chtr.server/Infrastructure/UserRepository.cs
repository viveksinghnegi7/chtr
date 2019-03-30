using chtr.server.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chtr.server.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserDatabase _userDatabase;

        public UserRepository(IUserDatabase userDatabase)
        {
            _userDatabase = userDatabase;
        }

        public Task AddUserAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<string[]> GetAll()
        {
            return Task.FromResult(_userDatabase.GetAll());
        }

        public Task RemoveUserAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}

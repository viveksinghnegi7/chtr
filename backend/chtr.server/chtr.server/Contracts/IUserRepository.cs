using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chtr.server.Contracts
{
    public interface IUserRepository
    {
        Task AddUserAsync(string userName);
        Task RemoveUserAsync(string userName);
        Task<string[]> GetAll();
    }
}

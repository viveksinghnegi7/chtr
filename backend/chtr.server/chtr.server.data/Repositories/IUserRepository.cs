using chtr.server.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.data.Repositories
{
    public interface IUserRepository
    {
        User GetUser(Guid id);
    }
}

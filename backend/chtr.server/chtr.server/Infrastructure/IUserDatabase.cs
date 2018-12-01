using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chtr.server.Infrastructure
{
    public interface IUserDatabase
    {
        string[] GetAll();
    }
}

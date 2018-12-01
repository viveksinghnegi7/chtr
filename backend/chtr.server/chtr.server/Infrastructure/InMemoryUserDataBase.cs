using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chtr.server.Infrastructure
{
    public class InMemoryUserDatabase : IUserDatabase
    {
        public string[] GetAll()
        {
            return new[] { "Monica", "John" };
        }
    }
}

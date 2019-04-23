using chtr.server.data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.api.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.FullName).Description("Presents the users full name");
            Field(x => x.UserName).Description("Presents the users username in a chat room");
        }
    }
}

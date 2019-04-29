using chtr.server.api.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.api.GraphQL.Schemas
{
    public class ChtrSchema : Schema
    {
        public ChtrSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<RoomQuery>();
        }
    }
}

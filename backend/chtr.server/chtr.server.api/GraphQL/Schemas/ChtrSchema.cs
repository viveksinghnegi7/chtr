using chtr.server.api.GraphQL.Mutations;
using chtr.server.api.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;

namespace chtr.server.api.GraphQL.Schemas
{
    public class ChtrSchema : Schema
    {
        public ChtrSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<BaseQuery>();
            Mutation = dependencyResolver.Resolve<BaseMutation>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using chtr.server.api.GraphQL.Extensions;
using chtr.server.api.GraphQL.Queries;
using GraphQL;

namespace chtr.server.api
{
    public class ApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DocumentExecuter>().As<IDocumentExecuter>();
            
            builder.RegisterQuery<RoomQuery>();

            base.Load(builder);
        }
    }
}

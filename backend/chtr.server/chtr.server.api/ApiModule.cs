﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using chtr.server.api.GraphQL.Extensions;
using chtr.server.api.GraphQL.Mutations;
using chtr.server.api.GraphQL.Queries;
using chtr.server.api.GraphQL.Schemas;
using chtr.server.api.GraphQL.Types;
using GraphQL;
using GraphQL.Types;

namespace chtr.server.api
{
    public class ApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DocumentExecuter>().As<IDocumentExecuter>();
            builder.RegisterType<ChtrSchema>().As<ISchema>();
            builder.RegisterType<BaseQuery>().AsSelf();
            builder.RegisterType<RoomType>().AsSelf();
            builder.RegisterType<UserType>().AsSelf();
            builder.RegisterType<BaseMutation>().AsSelf();
            builder.RegisterType<UserInputType>().AsSelf();
            base.Load(builder);
        }
    }
}

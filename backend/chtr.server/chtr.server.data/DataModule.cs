using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using chtr.server.data.Infrastructure;
using chtr.server.data.Repositories;

namespace chtr.server.data
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<RoomRepository>().As<IRoomRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}

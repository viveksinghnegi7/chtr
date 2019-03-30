using Autofac;
using chtr.server.Contracts;
using chtr.server.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chtr.server
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<InMemoryUserDatabase>().As<IUserDatabase>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}

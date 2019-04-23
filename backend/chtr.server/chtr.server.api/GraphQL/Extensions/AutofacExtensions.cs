using Autofac;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.api.GraphQL.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterQuery<TQuery>(this ContainerBuilder builder)
        {
            var name = typeof(TQuery).Name;
            var splitted = name.Split(new string[] { "Query" }, StringSplitOptions.None);

            if (splitted.Length != 2)
                throw new ArgumentException($"Name of {nameof(TQuery)} must end with 'Query'");

            builder.RegisterType<TQuery>().Named<TQuery>(splitted[0]);
        }

        public static IObjectGraphType GetQuery(this IComponentContext context, string queryType)
        {
            var query = context.ResolveNamed<IObjectGraphType>(queryType);
            return query;
        }
    }
}

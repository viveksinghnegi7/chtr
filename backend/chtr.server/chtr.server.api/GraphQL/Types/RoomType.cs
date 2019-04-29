using chtr.server.data.Entities;
using chtr.server.data.Infrastructure;
using chtr.server.data.Repositories;
using GraphQL.Types;
using GraphQLParser.AST;
using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.api.GraphQL.Types
{
    /// <summary>
    /// Defines the understanding of a Room and its sub fields
    /// </summary>
    public class RoomType : ObjectGraphType<Room>
    {
        public RoomType(IUserRepository userRepository)
        {
            Field(x => x.Id).Description("Identifier for a room");
            Field(x => x.Name).Description("Name of the room");
            Field<ListGraphType<UserType>, IEnumerable<User>>().Name("Users").Resolve(ctx =>
            {
                var roomId = ctx.Source.Id;
                return userRepository.GetUsersInRoom(roomId);
            });
        }
    }
}

using chtr.server.data.Entities;
using chtr.server.data.Infrastructure;
using chtr.server.data.Repositories;
using GraphQL.Types;
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
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;

        public RoomType()
        {
            Field(x => x.Id).Description("Identifier for a room");
            Field(x => x.Name).Description("Name of the room");
        }
    }
}

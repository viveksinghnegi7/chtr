using chtr.server.api.GraphQL.Types;
using chtr.server.data.Infrastructure;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.api.GraphQL.Queries
{
    public class RoomQuery : ObjectGraphType
    {
        private readonly IRoomRepository _roomRepository;

        public RoomQuery(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;

            Field<RoomType>(
                name: "Room",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "id" }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<Guid>("id");
                    return _roomRepository.GetRoom(id);
                });
        }
    }
}

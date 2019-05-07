using chtr.server.api.GraphQL.Types;
using chtr.server.data.Infrastructure;
using chtr.server.data.Repositories;
using GraphQL.Types;
using System;

namespace chtr.server.api.GraphQL.Queries
{
    public class RoomQuery : ObjectGraphType
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;

        public RoomQuery(IRoomRepository roomRepository, IUserRepository userRepository)
        {
            _roomRepository = roomRepository;
            _userRepository = userRepository;

            Field<RoomType>(
                name: "Room",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "id" }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<Guid>("id");
                    var room = _roomRepository.GetRoom(id);
                    return room;
                });
            Field<ListGraphType<RoomType>>(
                name: "Rooms",
                resolve: ctx => 
                {
                    return _roomRepository.GetRooms();
                });
            Field<UserType>(
                name: "User",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType>() { Name = "id" }),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<Guid>("id");
                    var user = _userRepository.GetUser(id);
                    return user;
                });
            Field<ListGraphType<UserType>>(
                name: "Users",
                resolve: ctx =>
                 {
                     return _userRepository.GetAll();
                 });
        }
    }
}

using chtr.server.api.GraphQL.Types;
using chtr.server.data.Entities;
using chtr.server.data.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.api.GraphQL.Mutations
{
    public class BaseMutation : ObjectGraphType
    {
        private readonly IUserRepository _userRepository;

        public BaseMutation(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            Field<UserType>("addUser",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ),
            resolve: context => {
                var user = context.GetArgument<User>("user");
                user.Id = Guid.NewGuid();
                _userRepository.Create(user);
                return true;
            });
            
        }
    }
}

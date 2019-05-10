using GraphQL.Types;

namespace chtr.server.api.GraphQL.Types
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field<NonNullGraphType<StringGraphType>>("userName");
            Field<NonNullGraphType<StringGraphType>>("fullName");
        }
    }
}

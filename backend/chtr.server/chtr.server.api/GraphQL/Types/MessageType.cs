using chtr.server.data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.api.GraphQL.Types
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Field(x => x.CreatedBy).Description("The user who created the messaage");
            Field(x => x.Content).Description("Content of the message");
            Field(x => x.CreatedInRoom).Description("In which chat room the message were posted to");
        }
    }
}

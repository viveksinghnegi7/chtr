using System;
using System.Collections.Generic;
using System.Text;

namespace chtr.server.data.Entities
{
    public class Room : EntityBase
    {
        public string Name { get; set; }
        public virtual List<Message> Conversation { get; set; }
        public virtual List<UserRoomRelation> UserRoom { get; set; }
    }
}

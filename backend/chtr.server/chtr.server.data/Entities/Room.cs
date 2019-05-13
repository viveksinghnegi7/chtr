using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace chtr.server.data.Entities
{
    [Table("rooms")]
    public class Room : EntityBase
    {
        public string Name { get; set; }
        public virtual List<Message> Conversation { get; set; }
        public virtual List<UserRoomRelation> UserRoom { get; set; }
    }
}

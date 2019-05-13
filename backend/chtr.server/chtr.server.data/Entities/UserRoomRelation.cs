﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace chtr.server.data.Entities
{
    [Table("userroomrelation")]
    public class UserRoomRelation
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}

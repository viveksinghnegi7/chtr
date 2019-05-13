using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace chtr.server.data.Entities
{
    [Table("users")]
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public byte[] Avatar { get; set; }
        public virtual List<UserRoomRelation> UserRoom { get; set; }
    }
}

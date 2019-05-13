using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace chtr.server.data.Entities
{
    [Table("messages")]
    public class Message : EntityBase
    {
        public virtual User CreatedBy { get; set; }
        public virtual Room CreatedInRoom { get; set; }
        public string Content { get; set; }
    }
}

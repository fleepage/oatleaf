using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Parent : BaseEntity
    {
        public long? UserId { get; set; }
        public int Rate { get; set; }
        public long? AccountsId { get; set; }
        public ICollection<Permissions> Permissions { get; set; }
        public ICollection<Student> Students { get; set; }

    }
}

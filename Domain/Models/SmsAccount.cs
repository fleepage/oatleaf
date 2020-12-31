using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class SmsAccount:BaseEntity
    {
        public long? SetupId { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string Password { get; set; }
        public int Unit { get; set; }
    }
}

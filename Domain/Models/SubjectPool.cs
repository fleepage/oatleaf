using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class SubjectPool : BaseEntity
    {
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Description { get; set; }
    }
}

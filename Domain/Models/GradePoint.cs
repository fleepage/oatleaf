using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class GradePoint : BaseEntity
    {
        public int StartRange { get; set; }
        public int EndRange { get; set; }
        [Column(TypeName = "nvarchar(8)")]
        public string Grade { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Remark { get; set; }
        public long? SetupId { get; set; }

    }
}

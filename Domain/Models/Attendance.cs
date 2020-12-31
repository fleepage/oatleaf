using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Attendance : BaseEntity
    {
        public long? StudentId { get; set; }
        public DateTime? Attended { get; set; }
        public bool IsPresent { get; set; }
        public long? RegisterId { get; set; }
    }
}

using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Register: BaseEntity
    {
        public ICollection<Attendance> Attendances { get; set; }
        public long? SetupId { get; set; }
        public DateTime Attendance { get; set; }
        public long? LevelId { get; set; }
        public int Total { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; }
        public long? TermId { get; set; }
        public long? CalledBy { get; set; }
    }
}

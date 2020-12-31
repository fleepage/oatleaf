using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Subjects : BaseEntity
    {
        public long? TeacherId { get; set; }
        public long? SetupId { get; set; }
        public long? SubjectPoolId { get; set; }
        public SubjectPool SubjectPool { get; set; }
        public long? LevelId { get; set; }
        public Level Level { get; set; }
        public ICollection<Assessment> Assessments { get; set; }

    }
}

using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Level : BaseEntity
    {
        public long? SetupId { get; set; }
        public long? TeacherId { get; set; }
        public int Stage { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Description { get; set; }
        public ICollection<Register> Registers { get; set; }
        public ICollection<Subjects> Subjects { get; set; }
        public ICollection<Assessment> Assessments { get; set; }
        public ICollection<SubjectCA> SubjectCAs { get; set; }
        public ICollection<TermCA> TermCAs { get; set; }
    }
}

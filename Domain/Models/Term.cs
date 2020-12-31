using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Term: BaseEntity
    {
        public long? SetupId { get; set; }
        public long? SessionId { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public virtual TermCA TermCA { get; set; }
        public ICollection<Register> Registers { get; set; }
        public ICollection<Assessment> Assessments { get; set; }
        public ICollection<SubjectCA> SubjectCAs { get; set; }
    }
}

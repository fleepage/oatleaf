using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class SubjectCA : BaseEntity
    {
        public ICollection<Assessment> Assessments { get; set; }
        public DateTime? CaDate { get; set; }
        public int TotalMark { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Remark { get; set; }
        public long? GradePointId { get; set; }
        public GradePoint GradePoint { get; set; }
        public long? SessionId { get; set; }
        public long? StudentsId { get; set; }
        public long? TeachersId { get; set; }
        public long? TermId { get; set; }
        public long? LevelId { get; set; }
        public long? SetupId { get; set; }
        public long? SubjectsId { get; set; }
        public long? TermCAId { get; set; }

    }
}

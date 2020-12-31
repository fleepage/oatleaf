using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class TermCA: BaseEntity
    {
        public ICollection<SubjectCA> SubjectCAs { get; set; }
        public DateTime? CaDate { get; set; }
        public int TotalMark { get; set; }
        public int Position { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Remark { get; set; }
        public long? GradePointId { get; set; }
        public GradePoint GradePoint { get; set; }
        public long? StudentsId { get; set; }
        public long? TeachersId { get; set; }
        public long? TermId { get; set; }
        public virtual Term Term { get; set; }
        public long? LevelId { get; set; }
        public long? SetupId { get; set; }
        public long? SchoolAdminId { get; set; }
        public long? StaffsId { get; set; }
    }
}

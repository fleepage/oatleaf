using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Assessment: BaseEntity
    {
        [Column(TypeName = "nvarchar(32)")]
        public string Type { get; set; }
        public DateTime? AssessmntDate { get; set; }
        public int Mark { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Remark { get; set; }
        public long? StudentsId { get; set; }
        public long? TeachersId { get; set; }
        public long? TermId { get; set; }
        public long? LevelId { get; set; }
        public long? SetupId { get; set; }
        public long? SubjectsId { get; set; }
        public long? SubjectCAId { get; set; }

    }
}

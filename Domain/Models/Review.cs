using fleepage.oatleaf.com.Domain.BaseEntities;
using fleepage.oatleaf.com.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Review:BaseEntity
    {
        [Column(TypeName = "nvarchar(256)")]
        public string Comment { get; set; }
        public Sentiment Sentiment { get; set; }
        public int Rating { get; set; }
        public long? StaffsId { get; set; }
        public long? StudentsId { get; set; }
        public long? TeachersId { get; set; }
        public long? SchoolAdminId { get; set; }
        public long? OrgAdminId { get; set; }
        public long? ParentId { get; set; }
        public long? MemberId { get; set; }
        public long? FreelanceId { get; set; }
        public long? SetupId { get; set; }
    }
}

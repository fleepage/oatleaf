using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Permissions : BaseEntity
    {
        [Column(TypeName = "nvarchar(64)")]
        public string Permission { get; set; }
        [Column(TypeName = "nvarchar(8)")]
        public string Level { get; set; }
        public long? StaffsId { get; set; }
        public long? StudentsId { get; set; }
        public long? TeachersId { get; set; }
        public long? SchoolAdminId { get; set; }
        public long? OrgAdminId { get; set; }
        public long? ParentId { get; set; }
        public long? MemberId { get; set; }
        public long? FreelanceId { get; set; }

    }
}

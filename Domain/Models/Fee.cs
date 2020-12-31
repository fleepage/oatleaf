using fleepage.oatleaf.com.Domain.BaseEntities;
using fleepage.oatleaf.com.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Fee  :BaseEntity
    {
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Description { get; set; }
        public FeeType Type { get; set; }
        public DateTime? FeeDate { get; set; }
        public bool IsPaid { get; set; }
        public virtual Transaction Transaction { get; set; }
        public long? TermId { get; set; }
        public long? StudentsId { get; set; }
        public long? StaffsId { get; set; }
        public long? TeachersId { get; set; }
        public long? SchoolId { get; set; }
        public long? OrganisationId { get; set; }
        public long? MemberId { get; set; }
    }
}

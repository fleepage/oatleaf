using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Student : BaseEntity
    {

        public long? UserId { get; set; }
        public long? SchoolId { get; set; }
        public virtual School School { get; set; }
        public long? ParentId { get; set; }
        public long? OrganisationId { get; set; }
        public int Rate { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Comment { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string AdmissionNumber { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public long? AdmittedBy { get; set; }
        public long? AccountsId { get; set; }
        public long? LevelId { get; set; }
        public ICollection<Permissions> Permissions { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Fee> Fees { get; set; }
        public ICollection<Assessment> Assessments { get; set; }
        public ICollection<SubjectCA> SubjectCAs { get; set; }


    }
}

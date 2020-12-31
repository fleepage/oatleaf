using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Teacher : BaseEntity
    {

        public long? UserId { get; set; }
        public long? SchoolId { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public int Rate { get; set; }
        public long? AccountsId { get; set; }
        public ICollection<Permissions> Permissions { get; set; }
        public ICollection<Subjects> Subjects { get; set; }
        public ICollection<Level> Levels { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Fee> Fees { get; set; }
        public ICollection<Assessment> Assessments { get; set; }
        public ICollection<SubjectCA> SubjectCAs { get; set; }
    }
}

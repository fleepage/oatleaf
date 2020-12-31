using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Setup : BaseEntity
    {
        public ICollection<Subjects> Subjects { get; set; }
        public ICollection<Level> Level { get; set; }
        public ICollection<Register> Register { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Term> Terms { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Assessment> Assessments { get; set; }
        public ICollection<SubjectCA> SubjectCAs { get; set; }
        public ICollection<TermCA> TermCAs { get; set; }
        public ICollection<GradePoint> GradePoints { get; set; }
        public long? SessionId { get; set; }
        public long? SemesterId { get; set; }
        public long? SmsAccountId { get; set; }
        public SmsAccount SmsAccount { get; set; }
        public long? SchoolId { get; set; }
        public School School { get; set; }
        public virtual  ContactList ContactList { get; set; }
        public int Percentage { get; set; }
    }
}

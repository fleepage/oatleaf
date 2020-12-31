using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Commands.Dto
{
    public class StudentRegisterDto
    {
        public StudentUserDto NewUser { get; set; }
        public long UserId { get; set; }
        public long SchoolId { get; set; }
        public string Comment { get; set; }
        public string AdmissionNumber { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public long? AdmittedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class StudentAccountDto
    {
        public long UserId { get; set; }
        public long SchoolId { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }
        public string AdmissionNumber { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public long? AdmittedBy { get; set; }
        public long? AccountsId { get; set; }
        //public ICollection<StudentPermissionDto> Permissions { get; set; }
    }
}

using fleepage.oatleaf.com.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Queries.Dto
{
    public class AccountDto
    {
        public long Id { get; set; }
        public string Role { get; set; }
        public bool isActive { get; set; }
        public virtual StaffAccountDto Staffs { get; set; }
        public virtual StudentAccountDto Students { get; set; }
        public virtual TeacherAccountDto Teachers { get; set; }
        public virtual SchoolAdminDto SchoolAdmin { get; set; }
        public virtual OrgAdminDto OrgAdmin { get; set; }
        public virtual ParentAccountDto Parent { get; set; }
        public virtual MemberAccountDto Member { get; set; }
        public virtual FreelanceAccountDto Freelance { get; set; }
    }
}

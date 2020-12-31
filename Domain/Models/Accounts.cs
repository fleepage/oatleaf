using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Accounts : BaseEntity
    {

        [Column(TypeName = "nvarchar(16)")]
        public string Role { get; set; }
        public bool isActive { get; set; }
        public virtual Staffs Staffs { get; set; }
        public virtual Student Students { get; set; }
        public virtual Teacher Teachers { get; set; }
        public virtual SchoolAdmin SchoolAdmin { get; set; }
        public virtual OrgAdmin OrgAdmin { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual Member Member { get; set; }
        public virtual Freelance Freelance { get; set; }
        public long? UserId { get; set; }
        public long? SchoolId { get; set; }
        public long? OrganisationId { get; set; }
        //public   User User { get; set; }

    }
}

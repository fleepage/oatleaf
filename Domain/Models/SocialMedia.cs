using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class SocialMedia : BaseEntity
    {
        public long? UserId { get; set; }
        public long? SchoolsId { get; set; }
        public long? OrganisationId { get; set; }
    }
}

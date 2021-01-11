using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class OrgAdmin: BaseEntity
    {

        public long? UserId { get; set; }
        public long? OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }
        public long? AccountsId { get; set; }
        public ICollection<Permissions> Permissions { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}

using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Subscriptions : BaseEntity
    {
        public long SubscriberId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public long Count { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public long? SubscriptionID { get; set; }
        public Subscription Subscription { get; set; }
    }
}

using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Subscription : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ActivePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal InActivePrice { get; set; }
        public int Type { get; set; }
        public int Duration { get; set; }
        public bool IsAvailable { get; set; }
    }
}

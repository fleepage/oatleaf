using fleepage.oatleaf.com.Domain.BaseEntities;
using fleepage.oatleaf.com.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public string Source { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Refrence { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string TransactionId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Comment { get; set; }
        public DateTime? TransactionDate { get; set; }
        public Status Status { get; set; }
        public TransactionType Type { get; set; }
        public long? FeeId { get; set; }
        public Fee Fee { get; set; }

    }
}

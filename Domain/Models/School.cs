using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class School : BaseEntity
    {
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }
        public bool IsFreelancer { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(9,6)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Identifier { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(32)")]
        public string Region { get; set; }
        public DateTime? FoundedAt { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string Founder { get; set; }
        public int Rate { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string BlockedMessage { get; set; }
        public virtual Setup Setup { get; set; }
        public ICollection<Subscriptions> Subscriptions { get; set; }
        public ICollection<Accounts> Accounts { get; set; }
        public ICollection<SocialMedia> SocialMedia { get; set; }
        public ICollection<Fee> Fees { get; set; }
    }
}

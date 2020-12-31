using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class Session : BaseEntity
    {
        public long? SetupId { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Term> Terms { get; set; }
        public ICollection<TermCA> TermCAs { get; set; }
    }
}

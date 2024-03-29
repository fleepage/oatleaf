﻿using fleepage.oatleaf.com.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Models
{
    public class SchoolAdmin: BaseEntity
    {

        public long? UserId { get; set; }
        public long? SchoolId { get; set; }
        public virtual School School { get; set; }
        public long? AccountsId { get; set; }
        public ICollection<Permissions> Permissions { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}

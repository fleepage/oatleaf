﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Commands.Dto
{
    public class CreateOrganisationDto
    {

        public long User { get; set; }
        public string Name { get; set; }

        public string Identifier { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }
        public DateTime? FoundedAt { get; set; }

        public string Founder { get; set; }
        public int Rate { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}

﻿using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Interfaces
{
    public interface IStaffRepository : IGenericRepository<Staffs>
    {
        Task<CreateStaffResponse> Create(Staffs teacher);
    }
}

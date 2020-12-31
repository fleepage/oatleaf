using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.DataAccess.Repository
{
    public class StaffRepository : GenericRepository<Staffs>, IStaffRepository
    {

        private readonly ApplicationDbContext context;

        public StaffRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));


        }

        public async Task<CreateStaffResponse> Create(Staffs staff)
        {
            var existingStaff = await context.Staffs.FirstOrDefaultAsync(x => x.SchoolId == staff.SchoolId && x.UserId == staff.UserId);

            if (existingStaff?.UserId == staff.UserId)
                return new CreateStaffResponse { Message = "Already a Staff in your school.", IsSuccess = false, Status = "" };


            await context.AddAsync(staff);
            await context.SaveChangesAsync();

            return new CreateStaffResponse { Message = "New Staff Created.", IsSuccess = true, Staff = staff, Status = "200" };
        }
    }
}

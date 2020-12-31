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
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {

        private readonly ApplicationDbContext context;

        public TeacherRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));


        }

        public async Task<CreateTeacherResponse> Create(Teacher teacher)
        {
            var existingTeacher = await context.Teachers.FirstOrDefaultAsync(x => x.SchoolId == teacher.SchoolId && x.UserId == teacher.UserId);

            if (existingTeacher?.UserId == teacher.UserId)
                return new CreateTeacherResponse { Message = "Already a Teacher in your school.", IsSuccess = false, Status = "" };


            await context.AddAsync(teacher);
            await context.SaveChangesAsync();

            return new CreateTeacherResponse { Message = "New Teacher Created.", IsSuccess = true, Teacher = teacher, Status = "200" };
        }
    }
}

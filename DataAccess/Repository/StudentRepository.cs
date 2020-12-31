using fleepage.oatleaf.com.Commands.Dto;
using fleepage.oatleaf.com.Domain.Interfaces;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using fleepage.oatleaf.com.Helper.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.DataAccess.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {

        private readonly ApplicationDbContext context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));


        }

        public async Task<bool> AssignParent(long student, long parent)
        {
            var existingStudent = await context.Students.FirstOrDefaultAsync(x => x.Id == student) ?? throw new AppException("Error Fetching record.");

            existingStudent.ParentId = parent;
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<StudentRegisterRsponse> Register(Student student)
        {


            var existingStudent = await context.Students.FirstOrDefaultAsync(x => x.SchoolId == student.SchoolId && x.UserId == student.UserId);

            if (existingStudent?.UserId == student.UserId)
                return new StudentRegisterRsponse { Message= "Already a student in your school.", IsSuccess = false, Status = "" };
             

            await context.AddAsync(student);
            await context.SaveChangesAsync();

            return new StudentRegisterRsponse { Message = "New Student Created.", IsSuccess = true, Student = student, Status = "200"};


        }
    }
}

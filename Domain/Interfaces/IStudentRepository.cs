using fleepage.oatleaf.com.Commands.Dto;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<StudentRegisterRsponse> Register(Student student);
        Task<bool> AssignParent(long student, long parent);
    }
}

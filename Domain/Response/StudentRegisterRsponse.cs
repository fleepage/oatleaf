using fleepage.oatleaf.com.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Domain.Response
{
    public class StudentRegisterRsponse
    {
        public bool IsSuccess { get; set; }
        public Student Student { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}

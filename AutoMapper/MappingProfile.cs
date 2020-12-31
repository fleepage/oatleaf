using AutoMapper;
using fleepage.oatleaf.com.Commands.Dto;
using fleepage.oatleaf.com.Domain.Models;
using fleepage.oatleaf.com.Queries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /*CreateMap<User, UserDetailsDto>();*/
            CreateMap<StudentUserDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<StudentRegisterDto, Student>();
            CreateMap<TeacherRegisterDto, Teacher>();
            CreateMap<StaffRegisterDto, Staffs>();
            CreateMap<ParentRegisterDto, Parent>();
            CreateMap<MemberRegisterDto, Member>();


            CreateMap<AccountDto, Accounts>().ReverseMap();
            CreateMap<StudentAccountDto, Student>().ReverseMap();
            CreateMap<TeacherAccountDto, Teacher>().ReverseMap();
            CreateMap<StaffAccountDto, Staffs>().ReverseMap();
            CreateMap<ParentAccountDto, Parent>().ReverseMap();
            CreateMap<MemberAccountDto, Member>().ReverseMap();
            CreateMap<FreelanceAccountDto, Freelance>().ReverseMap();
            CreateMap<SchoolAdminDto, SchoolAdmin>().ReverseMap();
            CreateMap<OrgAdminDto, OrgAdmin>().ReverseMap();


            CreateMap<PermissionAccountDto, Permissions>().ReverseMap();
            CreateMap<StudentPermissionDto, Permissions>().ReverseMap();
            CreateMap<SchoolAdminPermissionDto, Permissions>().ReverseMap();



            CreateMap<CreateSchoolDto, School>().ReverseMap();
            CreateMap<CreateOrganisationDto, Organisation>().ReverseMap();
        }
    }
}

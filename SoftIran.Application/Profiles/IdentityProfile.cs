
using AutoMapper;
using SoftIran.Application.ViewModels.Identity.User.Cmd;
using SoftIran.Application.ViewModels.Identity.User.Query;
using SoftIran.DataLayer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Profiles
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<UpsertUserCmd, ApplicationUser>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());
               
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(x => x.Department.Id));
        }

    }
}

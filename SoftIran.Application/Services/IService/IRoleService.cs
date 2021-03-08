using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Identity.Role.Cmd;
using SoftIran.Application.ViewModels.Identity.Role.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
    public interface IRoleService
    {
        Task<Response> UpsertRole(UpsertRoleCmd request);
        Task<Response> DeleteRole(string request);
        Task<Response<RoleDto>> GetRole(string request);
        Task<Response<RolesDto>> GetRoles(RolesQuery request);
        


    }
}

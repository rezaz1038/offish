using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Identity.User.Cmd;
using SoftIran.Application.ViewModels.Identity.User.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
    public interface IUserService
    {
        Task<Response> UpsertUser(UpsertUserCmd request);
        Task<Response> DeleteUser(string id);

        Task<Response<UsersDto>> GetUsers(UsersQuery request);
        Task<Response<UserDto>> GetUser(string id);

        Task<Response> ChangePassword(ChangePasswordCmd request);
        Task<Response> ResetPassword(ResetPasswordCmd request);
        Task<Response<AuthenticationToken>> LoginUser(LoginCmd request);

    }
}

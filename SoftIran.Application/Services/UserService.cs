

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Identity.Claims;
using SoftIran.Application.ViewModels.Identity.User.Cmd;
using SoftIran.Application.ViewModels.Identity.User.Query;
using SoftIran.DataLayer.Models.Context;
using SoftIran.DataLayer.Models.Entities;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services

{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly HttpContext _httpContext;
        private readonly AppDBContext _context;

        public UserService(UserManager<ApplicationUser> userManager,
                                IHttpContextAccessor httpContextAccessor,
                                RoleManager<ApplicationRole> roleManager,
                                IConfiguration configuration,
                               AppDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _httpContext = httpContextAccessor.HttpContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

       

        #region delete user
        public async Task<Response> DeleteUser(string id)
        {
            var user = await _userManager.Users.FirstAsync(z => z.Id == id);
            if (user == null)
            {
                throw new BusinessLogicException("رکوردی با این مشخصات یافت نشد");
            }
            await _userManager.DeleteAsync(user);
            return new Response
            {
                Status = true,
                Message = "success"

            };
        }
        #endregion

        #region GetUser
        public async Task<Response<UserDto>> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new BusinessLogicException("رکوردی با این مشخصات یافت نشد");
            }
            var item = new UserDto();
            item = _mapper.Map<UserDto>(user);

            return new Response<UserDto>
            {
                Data = item,
                Status = true,
                Message = "success"

            };
        }
        #endregion

 

        #region GetUsers
        public async Task<Response<UsersDto>> GetUsers(UsersQuery request)
        {
            var result = _userManager.Users
                .Include(x => x.Department)
                .AsQueryable();
            var finalResult = await result.ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToListAsync();
            var resultData = new UsersDto
            {
                Dtos = finalResult,
                PageId = request.PageId,
                PageSize = request.PageSize,
                Total = await result.CountAsync()
            };
            return new Response<UsersDto>
            {
                Data = resultData,
                Status = true,
                Message = "success"
            };


        }
        #endregion

        #region UpsertUser
        public async Task<Response> UpsertUser(UpsertUserCmd request)
        {
           ///// 
            var department = await _context.Departments
                    .FirstOrDefaultAsync(x => x.Id == request.DepartmentId);
                if (department == null)
                {
                    throw new BusinessLogicException("دپارتمان مورد تایید نمی باشد");
                }

          //////


            if (!string.IsNullOrEmpty(request.Id))
            {
                var user = await _userManager.FindByIdAsync(request.Id);
                if (user == null)
                {
                    throw new BusinessLogicException("کاربری برای ویرایش موجود نمی باشد");
                }
                user = _mapper.Map(request, user);
                user.Department = department;

                // update user role
                var roles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles);
                await _userManager.AddToRolesAsync(user, request.Roles);

                // removing all user claims
                var userClaims = await _userManager.GetClaimsAsync(user);
                var removeClaim = await _userManager.RemoveClaimsAsync(user, userClaims);
                if (!removeClaim.Succeeded)
                    throw new BusinessLogicException("خطای ناشناخته ای رخ داده است claims");

                // add claims to user
                var claims = ClaimStore.AllClaims.Where(x => request.Claims.Contains(x.Type)).ToList();
                foreach (var claim in claims)
                {
                    var resultAddition = await _userManager.AddClaimAsync(user, claim);
                    if (!resultAddition.Succeeded)
                        throw new BusinessLogicException("user خطای ناشناخته ای رخ داده است");
                }



                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    throw new Exception();
                }



            }
            else
            {
                var user = new ApplicationUser();

                var existingUser = await _userManager.FindByNameAsync(request.UserName);
                if (existingUser != null)
                {
                    throw new BusinessLogicException("این نام کاربری استفاده شده است. نام کاربری دیگری را امتحان کنید");
                }
                // user = await result.ProjectTo<ApplicationUser>(_mapper.ConfigurationProvider).First();
                user = _mapper.Map<ApplicationUser>(request);
                // user = _mapper.Map(request, user);
                user.Department = department;
                user.Id = Guid.NewGuid().ToString();
                //  user.UserName = request.UserName;
                // user.PasswordHash = request.Password;

                // add claims to user
                var claims = ClaimStore.AllClaims.Where(x => request.Claims.Contains(x.Type)).ToList();
                foreach (var claim in claims)
                {
                    var resultAddition = await _userManager.AddClaimAsync(user, claim);
                    if (!resultAddition.Succeeded)
                        throw new BusinessLogicException("خطای ناشناخته ای رخ داده است");
                }


                var res = await _userManager.CreateAsync(user, request.Password);

                if (!res.Succeeded)
                {
                    throw new BusinessLogicException("خطای ناشناخته");
                }
                await _userManager.AddToRolesAsync(user, request.Roles);
            }

            return new Response
            {
                Status = true,
                Message = "success"

            };


        }
        #endregion

        #region login
        public async Task<Response<AuthenticationToken>> LoginUser(LoginCmd request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new BusinessLogicException("رکوردی با این مشخصات یافت نشد");
            }
            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!userHasValidPassword)
            {
                throw new BusinessLogicException("نام کاربری و یا کلمه عبور را درست وارد نکرده اید");

            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var userRole = userRoles.FirstOrDefault();
            var userClaims = await _userManager.GetClaimsAsync(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim("id", user.Id),

                }),
                Expires = DateTime.UtcNow.Add(TimeSpan.Parse(_configuration["Jwt:TokenLifeTime"])),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Response<AuthenticationToken>
            {
                Status = true,
                Message = "success",
                Data = new AuthenticationToken
                {
                    Token = tokenHandler.WriteToken(token),
                    FirstName = user.FirstName,
                    LastName=user.LastName,
                    FullName = $"{user.FirstName} {user.LastName}",

                    UserId = user.Id,
                    UserName = user.UserName,

                    Avatar = user.Avatar ,
                    

                    Roles = userRoles,
                    Claims = userClaims.Select(c => c.Type).ToList()
                },
            };

        }
        #endregion

        #region ResetPassword
        public async Task<Response> ResetPassword(ResetPasswordCmd request)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                throw new BusinessLogicException("رکوردی با این مشخصات یافت نشد");
            }
            var userHashPassword = _userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            user.PasswordHash = userHashPassword;
           
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception();
            }

            return new Response
            {
                Status = true,
                Message = "success",

            };
        }
        #endregion

        #region ChangePassword
        public async Task<Response> ChangePassword(ChangePasswordCmd request)
        {
            var userId = _httpContext.GetUserId();
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, request.CurrentPassword);
            if (!userHasValidPassword)
            {
                throw new BusinessLogicException("رمز عبور صحیح نمی باشد");
            }

            var hashPassword = _userManager.PasswordHasher.HashPassword(user, request.NewPassword);
            user.PasswordHash = hashPassword;
            await _userManager.UpdateAsync(user);

            return new Response
            {
                Status = true,
                Message = "success"

            };
        }

        #endregion

        #region upload avatar

        public async Task<Response<UploadAvatarUserDto>> UploadAvatar(IFormFile file)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == _httpContext.GetUserId());
            var directory = Directory.GetParent(Environment.CurrentDirectory).ToString();
            var uploadPath = Path.Combine(directory, "Upload", "Avatar");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var completeName = Guid.NewGuid().ToString()
                             .Replace("-", string.Empty).Replace("+", string.Empty) + ".jpg";

            await using var fileStream = new FileStream(Path.Combine(uploadPath, completeName), FileMode.Create, FileAccess.Write);

            file.CopyTo(fileStream);
            fileStream.Flush();
            user.Avatar = completeName;
            await _context.SaveChangesAsync();

            return new Response<UploadAvatarUserDto>
            {
                Status = true,
                Data = new UploadAvatarUserDto
                {
                    Name = completeName,
                    Url = completeName.FileUrl()
                }
            };
           
        } 
        #endregion#
    }
}

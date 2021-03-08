using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Identity.Role.Cmd;
using SoftIran.Application.ViewModels.Identity.Role.Query;
using SoftIran.DataLayer.Models.Context;
using SoftIran.DataLayer.Models.Entities;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly HttpContext _httpContext;
        private readonly AppDBContext _context;

        public RoleService(UserManager<ApplicationUser> userManager,
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

        #region delete
        public async Task<Response> DeleteRole(string request)
        {
            var role = await _roleManager.FindByIdAsync(request);
            if (role == null)
            {
                throw new BusinessLogicException("رکوردی با این مشخصات یافت نشد");
            }
            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                throw new BusinessLogicException("خطایی در زمان حذف صورت پذیرفته است");
            }
            return new Response
            {
                Status = true,
                Message = "success"

            };


        }
        #endregion


        #region Get Role
        public async Task<Response<RoleDto>> GetRole(string request)
        {
            var role = await _roleManager.FindByIdAsync(request);
            if (role == null)
            {
                throw new BusinessLogicException("رکوردی با این مشخصات یافت نشد");
            }
            var result = new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
            return new Response<RoleDto>
            {
                Data = result,
                Status = true,
                Message = "success"

            };
        }
        #endregion


        #region List
        public async Task<Response<RolesDto>> GetRoles(RolesQuery request)
        {
            var result = _roleManager.Roles.AsQueryable();
            if (!string.IsNullOrEmpty(request.Name))
            {
                result = result.Where(x => x.Name.Contains(request.Name));
            }

            ///pagenating
            int take = request.PageSize;
            int skip = (request.PageId - 1) * take;

            int totalPages = (int)Math.Ceiling(result.Count() / (double)take);

            var finalResult = result.OrderBy(x => x.Name).Skip(skip).Take(take).AsQueryable();
            //----------------

            var resultData = new RolesDto
            {
                Dtos = await finalResult.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToListAsync(),

                PageId = request.PageId,
                PageSize = request.PageSize,
                Total = await result.CountAsync()
            };

            return new Response<RolesDto>
            {
                Data = resultData,
                Status = true,
                Message = "success"

            };
        }
        #endregion

        #region upsert
        public async Task<Response> UpsertRole(UpsertRoleCmd request)
        {
            /////
            var existItem = await _roleManager.FindByNameAsync(request.Name);
            if (existItem!=null)
            {
                throw new BusinessLogicException(".این رکورد از قبل موجود می باشد");
            }
            /////
            if (!string.IsNullOrEmpty(request.Id))
            {
                var role = await _roleManager.FindByIdAsync(request.Id);
                if (role == null)
                {
                    throw new BusinessLogicException("خطای ناشناخته ای رخ داده است");
                }
                role.Name = request.Name;
                var result = await _roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    throw new BusinessLogicException("ویرایش با شکست مواجه گردید");
                }

            }
            else
            {
                var role = new ApplicationRole();
                var existingRole = await _roleManager.FindByNameAsync(request.Name);
                if (existingRole != null)
                {
                    throw new BusinessLogicException("این رول از قبل ثبت گردیده است");
                }

                role.Id = Guid.NewGuid().ToString();
                role.Name = request.Name;

                var result = await _roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    throw new BusinessLogicException("خطایی صورت گرفته است");
                }

            }
            return new Response
            {
                Status = true,
                Message = "success"

            };
        }
        #endregion


    }
}

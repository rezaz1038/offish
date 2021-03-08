using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Offish.Cmd;
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
    public class OffishUpsertService : IOffishUpsert
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly HttpContext _httpContext;
        private readonly AppDBContext _context;

        public OffishUpsertService(UserManager<ApplicationUser> userManager,
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


        #region  ActionCancel
        public Task<Response> UpsertActionCancel(UpsertActionCancelCmd request)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ActionEquipmentDelivery
        public Task<Response> UpsertActionEquipmentDelivery(UpsertActionEquipmentDeliveryCmd request)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region ActionEquipmentRetake
        public Task<Response> UpsertActionEquipmentRetake(UpsertActionEquipmentRetakeCmd request)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region  ActionRegister
        public async Task<Response> UpsertActionRegister(UpsertActionRegisterCmd request)
        {
            var pgm = await _context.PGMs.SingleOrDefaultAsync(x => x.Id == request.PgmId);
            if (pgm == null)
            {
                throw new BusinessLogicException("چنین برنامه ای تعریف نشده است ");
            }

            var category = await _context.OffishCategories.SingleOrDefaultAsync(x => x.Id == request.CategoryId);
            if (category == null)
            {
                throw new BusinessLogicException("چنین گروهی تعریف نشده است ");
            }

            if (!string.IsNullOrEmpty(request.Id))
            {
                var item = await _context.Offishes.SingleOrDefaultAsync(z => z.Id == request.Id);

                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }
                //=> define ofish code
                item.PGM = pgm;
                item.Category = category;
                item.StartDate = request.StartDate;
                item.StartTime = request.StartTime;
                item.EndDate = request.EndDate;
                item.EndTime = request.EndTime;

                //avamel first delete avamel then add new offish users
                var existAvamel =  _context.OffishUsers.Where(x => x.OffishId == request.Id).AsQueryable();
                if (existAvamel != null)
                {
                    _context.OffishUsers.RemoveRange(existAvamel);
                    await _context.SaveChangesAsync();
                }
                foreach (var avamel in request.Avamel)
                {
                    var existUser = await _userManager.FindByIdAsync(avamel.UserId);
                    if (existUser == null)
                    {
                        throw new BusinessLogicException("چنین عواملی یافت نشد ");
                    }

                    var existRole = await _roleManager.FindByIdAsync(avamel.RoleId);
                    if (existRole == null)
                    {
                        throw new BusinessLogicException("چنین رولی یافت نشد ");
                    }


                    var employee = new OffishUser();
                    employee.Id = Guid.NewGuid().ToString();
                    employee.User = existUser;
                    employee.Role = existRole;
                    employee.CreatedAt = DateTime.Now;
                    employee.OffishId = item.Id;
                    await _context.OffishUsers.AddAsync(employee);

                }
                //avamel
                ///
                _context.Offishes.Update(item);


            }
            else
            {

                //creat


                var item = new Offish();

                item.Id = Guid.NewGuid().ToString();
                item.PGM = pgm;
                item.Category = category;
                item.StartDate = request.StartDate;
                item.StartTime = request.StartTime;
                item.EndDate = request.EndDate;
                item.EndTime = request.EndTime;
                //avamel
                foreach (var avamel in request.Avamel)
                {
                    var existUser = await _userManager.FindByIdAsync(avamel.UserId);
                    if (existUser == null)
                    {
                        throw new BusinessLogicException("چنین عواملی یافت نشد ");
                    }

                    var existRole = await _roleManager.FindByIdAsync(avamel.RoleId);
                    if (existRole == null)
                    {
                        throw new BusinessLogicException("چنین رولی یافت نشد ");
                    }


                    var employee = new OffishUser();
                    employee.Id = Guid.NewGuid().ToString();
                    employee.User = existUser;
                    employee.Role = existRole;
                    employee.CreatedAt = DateTime.Now;
                    employee.OffishId = item.Id;
                    await _context.OffishUsers.AddAsync(employee);

                }
                //avamel
                await _context.Offishes.AddAsync(item);


            }

            await _context.SaveChangesAsync();

            return new Response
            {
                Status = true,
                Message = "success"
            };

        }
        #endregion


        #region  ActionReject
        public async Task<Response> UpsertActionReject(UpsertActionRejectCmd request)
        {
            if (!string.IsNullOrEmpty(request.OffishId))
            {
                var item = await _context.Offishes.SingleOrDefaultAsync(z => z.Id == request.OffishId);

                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }

                // item.ActoinId = Guid.NewGuid().ToString();
                // item.PGMId=request.
                throw new BusinessLogicException("رکوردی یافت نشد");
            }
            throw new BusinessLogicException("رکوردی یافت نشد");
        }
        #endregion


    }
}

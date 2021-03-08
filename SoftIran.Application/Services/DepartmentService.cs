using Microsoft.EntityFrameworkCore;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Department.Query;
using SoftIran.Application.ViewModels.Department.Upsert;
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
    public class DepartmentService : IDepartment
    {
        private readonly AppDBContext _context;
        public DepartmentService(AppDBContext context)
        {
            _context = context;
        }

        #region Delete
        public async Task<Response> DeleteDepartment(string request)
        {
            if (!string.IsNullOrEmpty(request))
            {
                var item = await _context.Departments.SingleOrDefaultAsync(x => x.Id == request);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }
                _context.Departments.Remove(item);

            }
            await _context.SaveChangesAsync();
            return new Response
            {
                Status = true,
                Message = "success"
            };
        }
        #endregion

        #region Get Department
        public async Task<Response<DepartmentDto>> GetDepartment(string request)
        {
            var item = await _context.Departments.SingleOrDefaultAsync(x => x.Id == request);
            if (item == null)
            {
                throw new BusinessLogicException("رکوردی یافت نشد");
            }

            return new Response<DepartmentDto>
            {
                Status = true,
                Message = "success",
                Data = new DepartmentDto
                {
                    Id = item.Id,
                    Name = item.Name
                }
            };


        }

        #endregion

        #region Get Departments
        public async Task<Response<DepartmentsDto>> GetDepartments(DepartmentsQuery request)
        {
            var result = _context.Departments.AsQueryable();

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


            var resultData = new DepartmentsDto
            {
                Dtos = await finalResult.Select(d => new DepartmentDto()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToListAsync(),
                PageId = request.PageId,
                PageSize = request.PageSize,
                Total = await result.CountAsync()
            };

            return new Response<DepartmentsDto>
            {
                Data = resultData,


                Status = true,
                Message = "success"
            };


        }

        #endregion

        #region upsert
        public async Task<Response> UpsertDepartment(UpsertDepartmentCmd request)
        {
            /////
            var existItem= await _context.Departments.AnyAsync(x => x.Name == request.Name);
            if (existItem)
            {
                throw new BusinessLogicException(".این رکورد از قبل موجود می باشد");
            }
            /////

            if (!string.IsNullOrEmpty(request.Id))
            {
                var item = await _context.Departments.SingleOrDefaultAsync(x => x.Id == request.Id);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }

                item.Name = request.Name;
                _context.Departments.Update(item);

            }
            else
            {
                var item = new Department
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    CreatedAt = DateTime.Now
                };
                await _context.Departments.AddAsync(item);
            }
            await _context.SaveChangesAsync();

            return new Response
            {
                Status = true,
                Message = "success"
            };

        }

        #endregion

    }
}

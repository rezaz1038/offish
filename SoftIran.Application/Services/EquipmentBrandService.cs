using Microsoft.EntityFrameworkCore;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentBrand.Query;
using SoftIran.Application.ViewModels.EquipmentBrand.Upsert;
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
    public class EquipmentBrandService : IEquipmentBrand
    {
        #region Dependency Injection Context
        private readonly AppDBContext _context;

        public EquipmentBrandService(AppDBContext context)
        {
            _context = context;
        }
        #endregion
 
        #region delete
        public async Task<Response> DeleteEquipmentBrand(string request)
        {
            if (!string.IsNullOrEmpty(request))
            {
                var item = await _context.EquipmentBrands.SingleOrDefaultAsync(x => x.Id == request);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }
                _context.EquipmentBrands.Remove(item);

            }
            await _context.SaveChangesAsync();
            return new Response
            {
                Status = true,
                Message = "success"
            };
        }
        #endregion

        #region upsert
        public async Task<Response> UpsertEquipmentBrand(UpsertEquipmentBrandCmd request)
        {
            /////
            var existItem = await _context.EquipmentBrands.AnyAsync(x => x.Name == request.Name);
            if (existItem)
            {
                throw new BusinessLogicException(".این رکورد از قبل موجود می باشد");
            }
            /////
            if (!string.IsNullOrEmpty(request.Id))
            {
                var item = await _context.EquipmentBrands.SingleOrDefaultAsync(x => x.Id == request.Id);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }

                item.Name = request.Name;
                _context.EquipmentBrands.Update(item);

            }
            else
            {
                var item = new EquipmentBrand
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    CreatedAt = DateTime.Now
                };
                await _context.EquipmentBrands.AddAsync(item);
            }
            await _context.SaveChangesAsync();

            return new Response
            {
                Status = true,
                Message = "success"
            };
        }
        #endregion

        #region single
        public async Task<Response<EquipmentBrandDto>> GetEquipmentBrand(string request)
        {
            var item = await _context.EquipmentBrands.SingleOrDefaultAsync(x => x.Id == request);
            if (item == null)
            {
                throw new BusinessLogicException("رکوردی یافت نشد");
            }

            return new Response<EquipmentBrandDto>
            {
                Status = true,
                Message = "success",
                Data = new EquipmentBrandDto
                {
                    Id = item.Id,
                    Name = item.Name
                }
            };


        }

        #endregion

        #region Get EquipmentBrands
        public async Task<Response<EquipmentBrandsDto>> GetEquipmentBrands(EquipmentBrandsQuery request)
        {
            var result = _context.EquipmentBrands.AsQueryable();

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


            var resultData = new EquipmentBrandsDto
            {
                Dtos = await finalResult.Select(d => new EquipmentBrandDto()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToListAsync(),
                PageId = request.PageId,
                PageSize = request.PageSize,
                Total = await result.CountAsync()
            };

            return new Response<EquipmentBrandsDto>
            {
                Data = resultData,


                Status = true,
                Message = "success"
            };


        }

        #endregion

    }
}

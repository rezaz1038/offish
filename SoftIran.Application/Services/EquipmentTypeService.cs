using Microsoft.EntityFrameworkCore;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentType.Query;
using SoftIran.Application.ViewModels.EquipmentType.Upsert;
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
    public class EquipmentTypeService : IEquipmentType
    {
        #region Dependency Injection Context
        private readonly AppDBContext _context;

        public EquipmentTypeService(AppDBContext context)
        {
            _context = context;
        }
        #endregion
      
        #region delete
        public async Task<Response> DeleteEquipmentType(string request)
        {
            if (!string.IsNullOrEmpty(request))
            {
                var item = await _context.EquipmentTypes.SingleOrDefaultAsync(x => x.Id == request);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }
                _context.EquipmentTypes.Remove(item);

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
        public async Task<Response> UpsertEquipmentType(UpsertEquipmentTypeCmd request)
        {
            /////
            var existItem = await _context.EquipmentTypes.AnyAsync(x => x.Name == request.Name);
            if (existItem)
            {
                throw new BusinessLogicException(".این رکورد از قبل موجود می باشد");
            }
            /////
            if (!string.IsNullOrEmpty(request.Id))
            {
                var item = await _context.EquipmentTypes .SingleOrDefaultAsync(x => x.Id == request.Id);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }

                item.Name = request.Name;
                _context.EquipmentTypes.Update(item);

            }
            else
            {
                var item = new EquipmentType
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    CreatedAt=DateTime.Now
                
                };
                await _context.EquipmentTypes.AddAsync(item);
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
        public async Task<Response<EquipmentTypeDto>> GetEquipmentType(string id)
    {
            var item = await _context.EquipmentTypes.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new BusinessLogicException("رکوردی یافت نشد");
            }

            return new Response<EquipmentTypeDto>
            {
                Status = true,
                Message = "success",
                Data = new EquipmentTypeDto
                {
                    Id = item.Id,
                    Name = item.Name
                }
            };


        }

        #endregion

        #region Get EquipmentTypes
        public async Task<Response<EquipmentTypesDto>> GetEquipmentTypes(EquipmentTypesQuery request)
        {
            var result = _context.EquipmentTypes.AsQueryable();

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

            var resultData = new EquipmentTypesDto
            {
                Dtos = await finalResult.Select(d => new EquipmentTypeDto()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToListAsync(),
                PageId = request.PageId,
                PageSize = request.PageSize,
                Total = await result.CountAsync()
            };

            return new Response<EquipmentTypesDto>
            {
                Data = resultData,


                Status = true,
                Message = "success"
            };


        }

        #endregion


    }
}

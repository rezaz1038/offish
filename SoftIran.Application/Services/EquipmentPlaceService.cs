using Microsoft.EntityFrameworkCore;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentPlace.Query;
using SoftIran.Application.ViewModels.EquipmentPlace.Upsert;
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
    public class EquipmentPlaceService : IEquipmentPlace
    {
        #region Dependency Injection Context
        private readonly AppDBContext _context;

        public EquipmentPlaceService(AppDBContext context)
        {
            _context = context;
        }
        #endregion


        #region upsert


        public async Task<Response> UpsertEquipmentPlace(UpsertEquipmentPlaceCmd request)
        {
            /////
            var existItem = await _context.EquipmentPlaces.AnyAsync(x => x.Name == request.Name);
            if (existItem)
            {
                throw new BusinessLogicException(".این رکورد از قبل موجود می باشد");
            }
            /////
            if (!string.IsNullOrEmpty(request.Id))
            {
                var item = await _context.EquipmentPlaces.SingleOrDefaultAsync(x => x.Id == request.Id);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }

                item.Name = request.Name;
                _context.EquipmentPlaces.Update(item);

            }
            else
            {
                var item = new EquipmentPlace
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    CreatedAt = DateTime.Now
                };
                await _context.EquipmentPlaces.AddAsync(item);
            }
            await _context.SaveChangesAsync();

            return new Response
            {
                Status = true,
                Message = "success"
            };
        }

        #endregion

        #region delete
        public async Task<Response> DeleteEquipmentPlace(string request)
        {
            if (!string.IsNullOrEmpty(request))
            {
                var item = await _context.EquipmentPlaces.SingleOrDefaultAsync(x => x.Id == request);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }
                _context.EquipmentPlaces.Remove(item);

            }
            await _context.SaveChangesAsync();
            return new Response
            {
                Status = true,
                Message = "success"
            };
        }
        #endregion

        #region EquipmentPlace
        public async Task<Response<EquipmentPlaceDto>> GetEquipmentPlace(string id)
        {
            var item = await _context.EquipmentPlaces.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new BusinessLogicException("رکوردی یافت نشد");
            }

            return new Response<EquipmentPlaceDto>
            {
                Status = true,
                Message = "success",
                Data = new EquipmentPlaceDto
                {
                    Id = item.Id,
                    Name = item.Name
                }
            };


        }

        #endregion

        #region Get EquipmentPlaces
        public async Task<Response<EquipmentPlacesDto>> GetEquipmentPlaces(EquipmentPlacesQuery request)
        {
            var result = _context.EquipmentPlaces.AsQueryable();

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

            var resultData = new EquipmentPlacesDto
            {
                Dtos = await finalResult.Select(d => new EquipmentPlaceDto()
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToListAsync(),
                PageId = request.PageId,
                PageSize = request.PageSize,
                Total = await result.CountAsync()
            };

            return new Response<EquipmentPlacesDto>
            {
                Data = resultData,


                Status = true,
                Message = "success"
            };


        }

        #endregion

    }
}

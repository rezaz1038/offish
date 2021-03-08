using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Equipment.Query;
using SoftIran.Application.ViewModels.Equipment.Upsert;
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
    public class EquipmentService : IEquipment
    {
        #region Dependency Injection Context mapper
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public EquipmentService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region delete
        public async Task<Response> DeleteEquipment(string request)
        {
            if (!string.IsNullOrEmpty(request))
            {
                var item = await _context.Equipment.SingleOrDefaultAsync(x => x.Id == request);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }
                _context.Equipment.Remove(item);

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
        public async Task<Response> UpsertEquipment(UpsertEquipmentCmd request)
        {
            ///////////////////////////////////////
            //var technicalCode = await _context.Equipment.AnyAsync(x => x.TechnicalCode == request.TechnicalCode);
            //if (technicalCode)
            //{
            //    throw new BusinessLogicException("کد فنی قبلا استفاده شده است ");
            //}

            //var amval = await _context.Equipment.AnyAsync(x => x.Amval == request.Amval);
            //if (amval)
            //{
            //    throw new BusinessLogicException("کداموال قبلا استفاده شده است ");
            //}
            //////////////////////////////////////////

            var brand = await _context.EquipmentBrands.SingleOrDefaultAsync(x => x.Id == request.BrandId);
            var type = await _context.EquipmentTypes.SingleOrDefaultAsync(x => x.Id == request.TypeId);
            var place = await _context.EquipmentPlaces.SingleOrDefaultAsync(x => x.Id == request.PlaceId);

            ///updat insert

            if (!string.IsNullOrEmpty(request.Id))
            {
                var item = await _context.Equipment.SingleOrDefaultAsync(x => x.Id == request.Id);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }

                item = _mapper.Map<Equipment>(request);

                if (brand != null) item.Brand = brand;
                if (type != null) item.Type = type;
                if (place != null) item.Place = place;

                item.IsActive = true;
                _context.Equipment.Update(item);
            }
            else
            {
                var item = new Equipment();
                item = _mapper.Map<Equipment>(request);

                if (brand != null)   item.Brand = brand;
                if (type  != null)   item.Type = type;
                if (place != null)   item.Place = place;

                item.IsActive = true;
                item.Id = Guid.NewGuid().ToString();
                item.CreatedAt = DateTime.Now;
                await _context.Equipment.AddAsync(item);
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
        public async Task<Response<EquipmentDto>> GetEquipment(string id)
        {
            var item = await _context.Equipment.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new BusinessLogicException("رکوردی یافت نشد");
            }

            return new Response<EquipmentDto>
            {
                Status = true,
                Message = "success",
                Data = new EquipmentDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Amval = item.Amval,
                    BrandId = item.BrandId,
                    Description = item.Description,
                    IsActive = item.IsActive,
                    IsInUse = item.IsInUse,
                    Model = item.Model,
                    PlaceId = item.PlaceId,
                    Serial = item.Serial,
                    TechnicalCode = item.TechnicalCode,
                    TypeId = item.TypeId

                }
            };


        }

        #endregion

        #region Get Equipment 
        public async Task<Response<EquipmentsDto>> GetEquipments(EquipmentsQuery request)
        {
            var result = _context.Equipment.AsQueryable();

            ///filtering
            #region filter
            if (!string.IsNullOrEmpty(request.Name))
            {
                result = result.Where(x => x.Name.Contains(request.Name));
            }

            if (!string.IsNullOrEmpty(request.TechnicalCode))
            {
                result = result.Where(x => x.TechnicalCode.Contains(request.TechnicalCode));
            }

            if (!string.IsNullOrEmpty(request.Amval))
            {
                result = result.Where(x => x.Amval.Contains(request.Amval));
            }

            if (!string.IsNullOrEmpty(request.Model))
            {
                result = result.Where(x => x.Model.Contains(request.Model));
            }

            if (!string.IsNullOrEmpty(request.Serial))
            {
                result = result.Where(x => x.Serial.Contains(request.Serial));
            }

            if (request.IsActive == true)
            {
                result = result.Where(x => x.IsActive == request.IsActive);
            }

            if (request.IsInUse == true)
            {
                result = result.Where(x => x.IsActive == request.IsInUse);
            }

            if (!string.IsNullOrEmpty(request.BrandId))
            {
                result = result.Where(x => x.BrandId.Contains(request.BrandId));
            }

            if (!string.IsNullOrEmpty(request.TypeId))
            {
                result = result.Where(x => x.TypeId.Contains(request.TypeId));
            }

            if (!string.IsNullOrEmpty(request.PlaceId))
            {
                result = result.Where(x => x.PlaceId.Contains(request.PlaceId));
            }
            #endregion

             
            ///pagenating
            int take = request.PageSize;
            int skip = (request.PageId - 1) * take;

            int totalPages = (int)Math.Ceiling(result.Count() / (double)take);

            var finalResult = result.OrderBy(x => x.Name).Skip(skip).Take(take).AsQueryable();
            //----------------
             var list = await finalResult.ProjectTo<EquipmentDto>(_mapper.ConfigurationProvider)
               .ToListAsync();
            var resultData = new EquipmentsDto
            {
                Dtos=list,
                //Dtos = await finalResult.Select(d => new EquipmentDto()
                //{
                //    Id = d.Id,
                //    Name = d.Name,
                //    Amval = d.Amval,
                //    BrandId = d.BrandId,
                //    Description = d.Description,
                //    IsActive = d.IsActive,
                //    IsInUse = d.IsInUse,
                //    Model = d.Model,
                //    PlaceId = d.PlaceId,
                //    Serial = d.Serial,
                //    TechnicalCode = d.TechnicalCode,
                //    TypeId = d.TypeId

                //}).ToListAsync(),
                PageId = request.PageId,
                PageSize = request.PageSize,
                Total = await result.CountAsync()
            };

            return new Response<EquipmentsDto>
            {
                Data = resultData,


                Status = true,
                Message = "success"
            };


        }

        #endregion


    }

}

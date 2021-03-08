using Microsoft.EntityFrameworkCore;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.OffishCategoy.Cmd;
using SoftIran.Application.ViewModels.OffishCategoy.Query;
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
    public class OffishCategoryService : IOffishCategory
    {
        private readonly AppDBContext _context;
        public OffishCategoryService(AppDBContext context)
        {
            _context = context;
        }


    #region delete
        public async Task<Response> DeleteOffishCategory(string request)
        {
            if (!string.IsNullOrEmpty(request))
            {
                var item = await _context.OffishCategories.SingleOrDefaultAsync(x => x.Id == request);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }
                _context.OffishCategories.Remove(item);

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
    public async Task<Response> UpsertOffishCategory(UpsertOffishCategoryCmd request)
    {
            /////
            var existItem = await _context.OffishCategories.AnyAsync(x => x.Name == request.Name);
            if (existItem)
            {
                throw new BusinessLogicException(".این رکورد از قبل موجود می باشد");
            }
            /////
            if (!string.IsNullOrEmpty(request.Id))
        {
            var item = await _context.OffishCategories.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (item == null)
            {
                throw new BusinessLogicException("رکوردی یافت نشد");
            }

            item.Name = request.Name;
            _context.OffishCategories.Update(item);

        }
        else
        {
            var item = new OffishCategory
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                
               

                CreatedAt = DateTime.Now
            };
            await _context.OffishCategories.AddAsync(item);
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
    public async Task<Response<OffishCategoryDto>> GetOffishCategory(string request)
    {
        var item = await _context.OffishCategories.SingleOrDefaultAsync(x => x.Id == request);
        if (item == null)
        {
            throw new BusinessLogicException("رکوردی یافت نشد");
        }

        var result = new OffishCategoryDto

        {
            Id = item.Id,
            Name = item.Name,
           

        };

        return new Response<OffishCategoryDto>
        {
            Status = true,
            Message = "success",
            Data = result
        };


    }

    #endregion

    #region Get Categories
    public async Task<Response<OffishCategoriesDto>> GetOffishCategories(OffishCategoriesQuery request)
    {
        var result = _context.OffishCategories.AsQueryable();

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


        var resultData = new OffishCategoriesDto
        {
            Dtos = await finalResult.Select(d => new OffishCategoryDto()
            {
                Id = d.Id,
                Name = d.Name
            }).ToListAsync(),
            PageId = request.PageId,
            PageSize = request.PageSize,
            Total = await result.CountAsync()
        };

        return new Response<OffishCategoriesDto>
        {
            Data = resultData,


            Status = true,
            Message = "success"
        };


    }


}




    #endregion
}


     

  

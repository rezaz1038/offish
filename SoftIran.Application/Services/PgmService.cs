using Microsoft.EntityFrameworkCore;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Pgm.Cmd;
using SoftIran.Application.ViewModels.Pgm.Query;
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
    public class PgmService:IPgm
    {
        private readonly AppDBContext _context;

        public PgmService(AppDBContext context)
        {
            _context = context;
        }

        #region delete
        public async Task<Response> DeletePgm(string request)
        {
            if (!string.IsNullOrEmpty(request))
            {
                var item = await _context.PGMs.SingleOrDefaultAsync(x => x.Id == request);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }
                _context.PGMs.Remove(item);

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
        public async Task<Response> UpsertPgm(UpsertPgmCmd request)
        {
            /////
            var existItem = await _context.PGMs.AnyAsync(x => x.Name == request.Name);
            if (existItem)
            {
                throw new BusinessLogicException(".این رکورد از قبل موجود می باشد");
            }
            /////
            if (!string.IsNullOrEmpty(request.Id))
            {
                var item = await _context.PGMs.SingleOrDefaultAsync(x => x.Id == request.Id);
                if (item == null)
                {
                    throw new BusinessLogicException("رکوردی یافت نشد");
                }

                item.Name = request.Name;
                _context.PGMs.Update(item);

            }
            else
            {
                var item = new PGM
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    DepartmentId = request.DepartmentId,
                    CreatedAt = DateTime.Now
                };
                await _context.PGMs.AddAsync(item);
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
        public async Task<Response<PgmDto>> GetPgm(string request)
        {
            var item = await _context.PGMs.SingleOrDefaultAsync(x => x.Id == request);
            if (item == null)
            {
                throw new BusinessLogicException("رکوردی یافت نشد");
            }

            var result = new PgmDto 

            {
                Id = item.Id,
                Name = item.Name,
                DepartmentId=item.DepartmentId
                
            };

            return new Response<PgmDto>
            {
                Status = true,
                Message = "success",
                Data = result
            };


        }

        #endregion

        #region Get Pgms
        public async Task<Response<PgmsDto>> GetPgms(PgmsQuery request)
        {
            var result = _context.PGMs.AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
            {
                result = result.Where(x => x.Name.Contains(request.Name));
            }

            if (!string.IsNullOrEmpty(request.DepartmentId))
            {
                result = result.Where(x => x.Name.Contains(request.DepartmentId));
            }



            ///pagenating
            int take = request.PageSize;
            int skip = (request.PageId - 1) * take;

            int totalPages = (int)Math.Ceiling(result.Count() / (double)take);

            var finalResult = result.OrderBy(x => x.Name).Skip(skip).Take(take).AsQueryable();


            //----------------


            var resultData = new PgmsDto
            {
                Dtos = await finalResult.Select(d => new PgmDto()
                {
                    Id = d.Id,
                    Name = d.Name,
                    DepartmentId=d.DepartmentId
                }).ToListAsync(),
                PageId = request.PageId,
                PageSize = request.PageSize,
                Total = await result.CountAsync()
            };

            return new Response<PgmsDto>
            {
                Data = resultData,


                Status = true,
                Message = "success"
            };


        }

        
    }

  
 

        #endregion
    }
 

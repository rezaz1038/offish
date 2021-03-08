using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.OffishCategoy.Cmd;
using SoftIran.Application.ViewModels.OffishCategoy.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
    public interface IOffishCategory
    {
        Task<Response> UpsertOffishCategory(UpsertOffishCategoryCmd request);
        Task<Response> DeleteOffishCategory(string request);
        Task<Response<OffishCategoriesDto>> GetOffishCategories(OffishCategoriesQuery request);
        Task<Response<OffishCategoryDto>> GetOffishCategory(string request);
    }
}

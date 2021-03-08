using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentBrand.Query;
using SoftIran.Application.ViewModels.EquipmentBrand.Upsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
    public interface IEquipmentBrand
    {
        Task<Response> UpsertEquipmentBrand(UpsertEquipmentBrandCmd request);

        Task<Response> DeleteEquipmentBrand(string request);

        Task<Response<EquipmentBrandsDto>> GetEquipmentBrands(EquipmentBrandsQuery request);
        Task<Response<EquipmentBrandDto>> GetEquipmentBrand(string request);
    }
}

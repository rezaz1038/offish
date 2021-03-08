using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentType.Query;
using SoftIran.Application.ViewModels.EquipmentType.Upsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
    public interface IEquipmentType
    {
        Task<Response> UpsertEquipmentType(UpsertEquipmentTypeCmd request);
        Task<Response> DeleteEquipmentType(string request);
        Task<Response<EquipmentTypesDto>> GetEquipmentTypes(EquipmentTypesQuery request);
        Task<Response<EquipmentTypeDto>> GetEquipmentType(string id);
    }
}

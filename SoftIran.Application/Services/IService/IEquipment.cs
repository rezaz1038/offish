using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Equipment.Query;
using SoftIran.Application.ViewModels.Equipment.Upsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
    public interface IEquipment
    {
        Task<Response> UpsertEquipment(UpsertEquipmentCmd request);
        Task<Response> DeleteEquipment(string request);
        Task<Response<EquipmentsDto>> GetEquipments(EquipmentsQuery request);
        Task<Response<EquipmentDto>> GetEquipment(string id);
    }
}

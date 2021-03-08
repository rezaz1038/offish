using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentPlace.Query;
using SoftIran.Application.ViewModels.EquipmentPlace.Upsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
    public interface IEquipmentPlace
    {
        Task<Response> UpsertEquipmentPlace(UpsertEquipmentPlaceCmd request);

        Task<Response> DeleteEquipmentPlace(string request);

        Task<Response<EquipmentPlacesDto>> GetEquipmentPlaces(EquipmentPlacesQuery request);
        Task<Response<EquipmentPlaceDto>> GetEquipmentPlace(string id);
    }
}

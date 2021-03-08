using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Offish.Cmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
    public  interface IOffishUpsert
    {
        Task<Response> UpsertActionCancel(UpsertActionCancelCmd request);
        Task<Response> UpsertActionEquipmentDelivery(UpsertActionEquipmentDeliveryCmd request);
        Task<Response> UpsertActionEquipmentRetake(UpsertActionEquipmentRetakeCmd request);
        Task<Response> UpsertActionRegister(UpsertActionRegisterCmd request);
        Task<Response> UpsertActionReject(UpsertActionRejectCmd request);
        
    }
}

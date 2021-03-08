using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Pgm.Cmd;
using SoftIran.Application.ViewModels.Pgm.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
   public interface IPgm
    {
        Task<Response> UpsertPgm(UpsertPgmCmd request);
        Task<Response> DeletePgm(string request);
        Task<Response<PgmsDto>> GetPgms(PgmsQuery request);
        Task<Response<PgmDto>> GetPgm(string request);
    }
}

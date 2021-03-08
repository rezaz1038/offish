using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Department.Query;
using SoftIran.Application.ViewModels.Department.Upsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftIran.Application.Services.IService
{
    public interface IDepartment
    {
        Task<Response> UpsertDepartment(UpsertDepartmentCmd request);

        Task<Response> DeleteDepartment(string request);

        Task<Response<DepartmentsDto>> GetDepartments(DepartmentsQuery request);
        Task<Response<DepartmentDto>> GetDepartment(string request);

    }
}

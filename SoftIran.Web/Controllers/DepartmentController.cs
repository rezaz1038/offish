using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Department.Query;
using SoftIran.Application.ViewModels.Department.Upsert;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiVersion("1.0")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _service;

        public DepartmentController(IDepartment service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route(MapRoutes.Department.Upsert)]
        public async Task<IActionResult> UpsertDepartment([FromBody] UpsertDepartmentCmd request)
        {
            try
            {
                var result = await _service.UpsertDepartment(request);
                return Ok(result);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = ex.Message
                });

            }
            catch (Exception e)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = ErrorMessages.UnkownError
                });
            }
 

        }
        #endregion

        #region list

        [HttpGet]
        [Route(MapRoutes.Department.List)]
        public async Task<IActionResult> ListDepartments([FromQuery] DepartmentsQuery request)
        {
            try
            {
                var result = await _service.GetDepartments(request);
                return Ok(result);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = ex.Message
                });

            }
            catch (Exception e)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = ErrorMessages.UnkownError
                });
            }

        }
        #endregion

        #region get department
        [HttpGet]
        [Route(MapRoutes.Department.Single)]
        public async Task<IActionResult> SingleDepartment([FromRoute] string request)
        {
            try
            {
                var result = await _service.GetDepartment(request);
                return Ok(result);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = ex.Message
                });

            }
            catch (Exception e)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = ErrorMessages.UnkownError
                });
            }

        }
        #endregion

        #region delete
        [HttpDelete(MapRoutes.Department.Delete)]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteDepartment(request);
                return Ok(result);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = "BusinessLogic Error"
                });

            }
            catch (Exception e)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message = ErrorMessages.UnkownError
                });
            }
        }

        #endregion


    }
}

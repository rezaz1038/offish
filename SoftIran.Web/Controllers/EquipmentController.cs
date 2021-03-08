using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Equipment.Query;
using SoftIran.Application.ViewModels.Equipment.Upsert;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiVersion("1.0")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipment _service;

        public EquipmentController(IEquipment service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route(MapRoutes.Equipment.Upsert)]
        public async Task<IActionResult> UpsertEquipment ([FromBody] UpsertEquipmentCmd request)
        {
            try
            {
                var result = await _service.UpsertEquipment(request);
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
                    Message = e.StackTrace
                });
            }
        }
        #endregion

        #region delete
        [HttpDelete(MapRoutes.Equipment.Delete)]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteEquipment(request);
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

        #region list

        [HttpGet]
        [Route(MapRoutes.Equipment.List)]
        public async Task<IActionResult> ListEquipments([FromQuery] EquipmentsQuery request)
        {
            try
            {
                var result = await _service.GetEquipments(request);
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
                    //Message = ErrorMessages.UnkownError
                    Message = e.Message
                });
            }





        }
        #endregion

        #region get  single
        [HttpGet]
        [Route(MapRoutes.Equipment.Single)]
        public async Task<IActionResult> SingleEquipment([FromRoute] string request)
        {
            try
            {
                var result = await _service.GetEquipment(request);
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
    }
}

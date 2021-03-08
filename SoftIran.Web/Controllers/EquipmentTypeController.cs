using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentType.Query;
using SoftIran.Application.ViewModels.EquipmentType.Upsert;
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
    public class EquipmentTypeController : ControllerBase
    {
        private readonly IEquipmentType _service;
        public EquipmentTypeController(IEquipmentType service)
        {
            _service = service;
        }


        #region upsert
        [HttpPost]
        [Route(MapRoutes.Equipment.Type.Upsert)]
        public async Task<IActionResult> UpsertEquipmentType([FromBody] UpsertEquipmentTypeCmd request)
        {
            try
            {
                var result = await _service.UpsertEquipmentType(request);
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
        [HttpDelete(MapRoutes.Equipment.Type.Delete)]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteEquipmentType(request);
                return Ok(result);
            }
            catch (BusinessLogicException ex)
            {
                return BadRequest(new Response
                {
                    Status = false,
                    Message =ex.Message
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
        [Route(MapRoutes.Equipment.Type.List)]
        public async Task<IActionResult> ListEquipmentTypes([FromQuery] EquipmentTypesQuery request)
        {
            try
            {
                var result = await _service.GetEquipmentTypes(request);
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

        #region get  single
        [HttpGet]
        [Route(MapRoutes.Equipment.Type.Single)]
        public async Task<IActionResult> SingleEquipmentType([FromRoute] string request)
        {
            try
            {
                var result = await _service.GetEquipmentType(request);
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

using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.EquipmentPlace.Query;
using SoftIran.Application.ViewModels.EquipmentPlace.Upsert;
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
    public class EquipmentPlaceController : ControllerBase
    {
        private readonly IEquipmentPlace _service;
        public EquipmentPlaceController(IEquipmentPlace service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route(MapRoutes.Equipment.Place.Upsert)]
        public async Task<IActionResult> UpsertEquipmentPlace([FromBody] UpsertEquipmentPlaceCmd request)
        {
            try
            {
                var result = await _service.UpsertEquipmentPlace(request);
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
        [HttpDelete(MapRoutes.Equipment.Place.Delete)]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteEquipmentPlace(request);
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
        [Route(MapRoutes.Equipment.Place.List)]
        public async Task<IActionResult> ListEquipmentPlaces([FromQuery] EquipmentPlacesQuery request)
        {
            try
            {
                var result = await _service.GetEquipmentPlaces(request);
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
        [Route(MapRoutes.Equipment.Place.Single)]
        public async Task<IActionResult> SingleEquipmentPlace([FromRoute] string request)
        {
            try
            {
                var result = await _service.GetEquipmentPlace(request);
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

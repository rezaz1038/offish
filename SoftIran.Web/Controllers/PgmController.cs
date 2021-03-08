using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Pgm.Cmd;
using SoftIran.Application.ViewModels.Pgm.Query;
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
    public class PgmController : ControllerBase
    {

        private readonly IPgm _service;
        public PgmController(IPgm  service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route(MapRoutes.PGM.Upsert)]
        public async Task<IActionResult> UpsertPgm([FromBody] UpsertPgmCmd request)
        {
            try
            {
                var result = await _service.UpsertPgm(request);
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
        [HttpDelete(MapRoutes.PGM.Delete)]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeletePgm(request);
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
        [Route(MapRoutes.PGM.List)]
        public async Task<IActionResult> ListPgms([FromQuery] PgmsQuery request)
        {
            try
            {
                var result = await _service.GetPgms(request);
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
        [Route(MapRoutes.PGM.Single)]
        public async Task<IActionResult> SinglePgm([FromRoute] string request)
        {
            try
            {
                var result = await _service.GetPgm(request);
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




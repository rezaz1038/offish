using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.OffishCategoy.Cmd;
using SoftIran.Application.ViewModels.OffishCategoy.Query;
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
    public class OffishCategoryController : ControllerBase
    {

        private readonly IOffishCategory _service;
        public OffishCategoryController(IOffishCategory  service)
        {
            _service = service;
        }

        #region upsert
        [HttpPost]
        [Route(MapRoutes.Offish.Category.Upsert)]
        public async Task<IActionResult> UpsertCategory([FromBody]UpsertOffishCategoryCmd request)
        {
            try
            {
                var result = await _service.UpsertOffishCategory(request);
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
        [HttpDelete(MapRoutes.Offish.Category.Delete)]
        public async Task<ActionResult> Delete([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteOffishCategory(request);
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
        [Route(MapRoutes.Offish.Category.List)]
        public async Task<IActionResult> List([FromQuery] OffishCategoriesQuery request)
        {
            try
            {
                var result = await _service.GetOffishCategories(request);
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
        [Route(MapRoutes.Offish.Category.Single)]
        public async Task<IActionResult> Single([FromRoute] string request)
        {
            try
            {
                var result = await _service.GetOffishCategory(request);
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

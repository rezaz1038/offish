using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftIran.Application.Services.IService;
using SoftIran.Application.ViewModels;
using SoftIran.Application.ViewModels.Identity.User.Cmd;
using SoftIran.Application.ViewModels.Identity.User.Query;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService  service)
        {
            _service = service;
        }

        #region list

        [HttpGet]
        [Route(MapRoutes.User.List)]
        [ProducesResponseType(typeof(Response<UsersDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListUsers([FromQuery] UsersQuery request)
        {
            try
            {
                var result = await _service.GetUsers(request);
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

        #region upsert
        [HttpPost]
        [Route(MapRoutes.User.Upsert)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpsertUser([FromBody] UpsertUserCmd request)
        {
            try
            {
                var result = await _service.UpsertUser(request);
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
                     //e.Message 
                }); 
            }
        }
        #endregion

        #region delete
        [HttpDelete(MapRoutes.User.Delete)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteUser([FromRoute] string request)
        {
            try
            {
                var result = await _service.DeleteUser(request);
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

        #region get  single
        [HttpGet]
        [Route(MapRoutes.User.Single)]
        [ProducesResponseType(typeof(Response<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SingleUser([FromRoute] string request)
        {
            try
            {
                var result = await _service.GetUser(request);
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


        #region login
        [AllowAnonymous]
        [HttpPost]
        [Route(MapRoutes.User.Login)]
        [ProducesResponseType(typeof(Response<AuthenticationToken>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login ([FromBody] LoginCmd request) 
        {
            try
            {
                var result = await _service.LoginUser(request);
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
                    //e.Message 
                });
            }
        }
        #endregion


        #region reset password
        [HttpPost]
        [Route(MapRoutes.User.ResetPassword)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordUser([FromBody] ResetPasswordCmd request)
        {
            try
            {
                var result = await _service.ResetPassword(request);
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
                    //e.Message 
                });
            }
        }
        #endregion

        #region change password
        [HttpPost]
        [Route(MapRoutes.User.ChangePassword)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCmd request)
        {
            try
            {
                var result = await _service.ChangePassword(request);
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
                    //e.Message 
                });
            }
        }
        #endregion

        #region uploadAvatar
         [HttpPost]
         [Route(MapRoutes.User.UploadAvatar)]
        [ProducesResponseType(typeof(Response<UploadAvatarUserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadAvatar( IFormFile request)
        {
            try
            {
                var result = await _service.UploadAvatar(request);
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
                    //e.Message 
                });
            }
        }
        #endregion

    }
}

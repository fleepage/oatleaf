using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fleepage.oatleaf.com.Commands;
using fleepage.oatleaf.com.Helper.Exceptions;
using fleepage.oatleaf.com.Queries;
using fleepage.oatleaf.com.Queries.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fleepage.oatleaf.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger;
        }




        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> signin([FromBody] LoginQuery request)
        {
            try
            {
                var result = await mediator.Send(request);

                if(result.IsSuccess)
                    return Ok(result.UserDto);
                else
                    return BadRequest(new { result.IsSuccess,result.Message });
            }
            catch (EntityNotFoundException ex)
            {

                return BadRequest(new { message = ex.Message });
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> signup([FromBody] CreateUserCommand request)
        {
            try
            {
                var result = await mediator.Send(request);

                if (result.IsSuccess)
                    return Ok(new { result.User.Id, result.Message, result.IsSuccess});
                else
                    return BadRequest(new { result.Message, result.IsSuccess });
            }
            catch (AppException ex)
            {

                // return await BadRequest(new { message = ex.Message });
                return BadRequest(new { message = ex.Message, IsSuccess=false });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
        }


        [HttpPost]
        [Route("forgot")]
        public ActionResult forgotPassword()
        {
            return Ok();
        }


    }
}

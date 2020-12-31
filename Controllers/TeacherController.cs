using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using fleepage.oatleaf.com.Commands;
using fleepage.oatleaf.com.Helper.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fleepage.oatleaf.com.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly IMediator mediator;

        public TeacherController(ILogger<TeacherController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }




        [Authorize(Roles = "staffRW")]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> create([FromBody] CreateTeacherCommand request)
        {
            try
            {
                var tenant = HttpContext.User.Claims;

                if (tenant.Where(c => c.Type == "Tenant").FirstOrDefault().Value == "" + request.registerDto.SchoolId)
                {
                    request.registerDto.SchoolId = long.Parse(tenant.Where(c => c.Type == "Tenant").FirstOrDefault().Value);
                    //request.registerDto.AdmittedBy = long.Parse(tenant.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value);
                    var result = await mediator.Send(request);

                    if (result.IsSuccess)
                        return Ok(new { result.Teacher.Id, result.Message, result.IsSuccess });
                    else
                        return BadRequest(new { result.Message, result.IsSuccess });
                }
                else
                {
                    return Forbid();
                }
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, IsSuccess = false });
            }
        }

        [HttpGet]
        public ActionResult get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok();
        }

    }
}

using fleepage.oatleaf.com.Commands;
using fleepage.oatleaf.com.Helper.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private readonly ILogger<StaffController> _logger;
        private readonly IMediator mediator;

        public StaffController(ILogger<StaffController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }




        [Authorize(Roles = "staffRW")]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> create([FromBody] CreateStaffCommand request)
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
                        return Ok(new { result.Staff.Id, result.Message, result.IsSuccess });
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

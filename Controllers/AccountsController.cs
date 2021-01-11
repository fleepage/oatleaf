using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using fleepage.oatleaf.com.Helper.Exceptions;
using fleepage.oatleaf.com.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fleepage.oatleaf.com.Controllers
{
    [EnableCors("FrontEnd")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IMediator mediator;
        

        public AccountsController(ILogger<AccountsController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            
        }

        [HttpPost]
        [Route("select")]
        public async Task<IActionResult> select([FromBody] SelectAccountQuery request)
        {
            try
            {
                var tenant = HttpContext.User.Claims;
                request.selectAccountDto.UserId = long.Parse(tenant.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value);
                var result = await mediator.Send(request);

                if (result.IsSuccess) {
                    return Ok(new { result.Message, result.token, result.Permissions });
                }
                else {
                    return BadRequest(new { result.Message});
                }
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = "Claims "+ex.Message });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Claims " + ex.Message });
            }
        }

        [HttpPost]
        [Route("MyAccounts")]
        public async Task<IActionResult> MyAccountsAsync( )
        {
            try
            {
                MyAccountsQuery request = new MyAccountsQuery();
                var tenant = HttpContext.User.Claims;
                request.user = long.Parse(tenant.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value);
                var result = await mediator.Send(request);

                if (result.IsSuccess)
                {
                    return Ok(new { result.Message, result.MyAccounts });
                }
                else
                {
                    return BadRequest(new { result.Message });
                }
            }
            catch (AppException ex)
            {

                return BadRequest(new { message = "Claims " + ex.Message });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Claims " + ex.Message });
            }
        }
    }
}

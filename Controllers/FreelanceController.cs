﻿using System;
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
    public class FreelanceController : ControllerBase
    {


        private readonly ILogger<SchoolController> _logger;
        private readonly IMediator mediator;

        public FreelanceController(ILogger<SchoolController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> createAsync([FromBody] EnableFreelanceCommand request)
        {
            try
            {
                var tenant = HttpContext.User.Claims;

                request.schoolDto.User = long.Parse(tenant.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value);

                var result = await mediator.Send(request);

                if (result.IsSuccess)
                    return Ok(new { result.Identifier, result.Message, result.IsSuccess });
                else
                    return BadRequest(new { result.Message, result.IsSuccess });

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
        [Route("verify")]
        public ActionResult Identifier()
        {
            return Ok();
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

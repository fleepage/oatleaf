using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fleepage.oatleaf.com.Helper.Notification;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fleepage.oatleaf.com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IMediator mediator;

        public NotificationController(ILogger<StudentController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }

        [HttpGet]
        public ActionResult get()
        {
            

            return Ok(new { Result = Sms.SendSms()  });

        }
    }
}

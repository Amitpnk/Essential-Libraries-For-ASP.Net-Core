using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Models;
using SendGrid.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGridAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailService _emailService
            ;
        public MailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] Email request)
        {
            try
            {
                await _emailService.SendEmail(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

    }
}

using Microsoft.AspNetCore.Mvc;
using TwoFactorAuthService.Api.Modal;

namespace TwoFactorAuthService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwoFactorController : ControllerBase
    {
        private readonly ITwoFactorService twoFactorService;

        public TwoFactorController(ITwoFactorService twoFactorService)
        {
            this.twoFactorService = twoFactorService;
        }

        [HttpPost("send-code")]
        public IActionResult SendCode([FromBody] PhoneRequest request)
        {
            var result = twoFactorService.SendCode(request.Phone);
            if (result)
            {
                return Ok(new { Message = "Code sent successfully." });
            }

            return BadRequest(new { Message = "Too many active codes for the phone." });
        }

        [HttpPost("verify-code")]
        public IActionResult VerifyCode([FromBody] VerifyCodeRequest request)
        {
            var result = twoFactorService.VerifyCode(request.Phone, request.Code);
            if (result)
            {
                return Ok(new { Message = "Code verified successfully." });
            }

            return BadRequest(new { Message = "Code verification failed." });
        }
    }
}

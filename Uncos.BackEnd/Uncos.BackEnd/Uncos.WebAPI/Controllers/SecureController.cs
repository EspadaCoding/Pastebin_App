using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Uncos.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : BaseController
    {
        [HttpGet("check-IsAuthenticated")] 
        public IActionResult Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(new { Message = "User is authenticated", User = User.Identity.Name });
            }
            else
            {
                return Unauthorized(new { Message = "User is not authenticated" });
            }
        }

        [HttpGet("secure-data")] 
        public IActionResult GetSecureData()
        {
            var userId = UserId;
            if (userId == Guid.Empty)
            {
                return Unauthorized("User is not authenticated.");
            }

            // Use the Mediator to handle some business logic
            // var result = await Mediator.Send(new SomeQuery { UserId = userId });

            return Ok(new { Message = "User is authenticated", UserId = userId });
        }
    }
}

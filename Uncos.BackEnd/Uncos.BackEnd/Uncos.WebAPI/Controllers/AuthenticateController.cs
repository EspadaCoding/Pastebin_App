using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Uncos.Domain;
using Uncos.WebAPI.Models.AuthModels;
using Uncos.WebAPI.Services;

namespace Uncos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var result = await _userService.RegisterAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _userService.LoginAsync(model);
            if (result == null)
            {
                return Unauthorized(new Response { Status = "Error", Message = "Invalid credentials" });
            }

            return Ok(result);
        }
         
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        { 
            return Ok(await _userService.LogoutAsync());
        }


    }
} 

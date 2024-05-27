using System;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Uncos.WebAPI.Services;

namespace Uncos.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator =>
            _mediator ??= HttpContext?.RequestServices.GetService<IMediator>();

        internal Guid UserId
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Guid.Empty;
                }

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (Guid.TryParse(userIdClaim, out var userId))
                {
                    return userId;
                }

                return Guid.Empty;
            }
        }
    }















}

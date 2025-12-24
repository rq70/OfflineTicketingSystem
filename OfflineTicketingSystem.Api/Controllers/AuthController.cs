using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfflineTicketingSystem.Application.Auth.Commands;
using OfflineTicketingSystem.Application.Auth.DTOs;

namespace OfflineTicketingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var result = await _mediator.Send(
                new LoginCommand(dto.Email, dto.Password));
            return Ok(result);
        }
    }
}

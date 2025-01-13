using Microsoft.AspNetCore.Mvc;
using DeveloperToolTip.Application.DTOs.AuthDTOs;
using DeveloperToolTip.Application.InterfacesApp;
using DeveloperToolTip.Application.UseCases.AuthUseCases;
using Microsoft.AspNetCore.Authorization;

namespace DeveloperToolTip.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IAuthenticateDeveloperUseCase _authenticateDeveloperUseCase;

        public AuthController(IJwtTokenGenerator jwtTokenGenerator, IAuthenticateDeveloperUseCase authenticateDeveloperUseCase)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _authenticateDeveloperUseCase = authenticateDeveloperUseCase;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                // Validar credenciales usando el caso de uso
                var token = await _authenticateDeveloperUseCase.ExecuteAsync(loginDto);

                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(new { Token = token });
                }

                return Unauthorized(new { Message = "Invalid credentials" });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }


    }
}

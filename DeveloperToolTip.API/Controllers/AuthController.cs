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

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Obtener el DeveloperId del token de usuario autenticado
                var developerId = int.Parse(User.FindFirst("DeveloperId")?.Value ?? "0");

                // Finalizar la sesión activa del Developer
                var success = await _authenticateDeveloperUseCase.EndSessionAsync(developerId);

                if (success)
                {
                    return Ok(new { Message = "Logout successful" });
                }

                return BadRequest(new { Message = "No active session found to logout" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpGet("active-session")]
        [Authorize]
        public async Task<IActionResult> GetActiveSession()
        {
            try
            {
                // Obtener el DeveloperId del token de usuario autenticado
                var developerId = int.Parse(User.FindFirst("DeveloperId")?.Value ?? "0");

                // Recuperar la sesión activa
                var activeSession = await _authenticateDeveloperUseCase.GetActiveSessionAsync(developerId);

                if (activeSession != null)
                {
                    return Ok(new
                    {
                        SessionId = activeSession.Id,
                        DeveloperId = activeSession.DeveloperId,
                        //LoginDate = activeSession.LoginDate,
                        IpAddress = activeSession.IpAddress,
                        IsActive = activeSession.IsActive,
                        //Developer = new
                        //{
                        //    activeSession.Developer.Id,
                        //    activeSession.Developer.FirstName,
                        //    activeSession.Developer.Email,
                        //    activeSession.Developer.RoleId
                        //}
                    });
                }

                return NotFound(new { Message = "No active session found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

    }
}

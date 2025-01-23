using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.AuthDTOs;
using DeveloperToolTip.Application.InterfacesApp;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;


namespace DeveloperToolTip.Application.UseCases.AuthUseCases
{
    public class AuthenticateDeveloperUseCase : IAuthenticateDeveloperUseCase
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticateDeveloperUseCase(IDeveloperRepository developerRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _developerRepository = developerRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> ExecuteAsync(LoginDto dto)
        {
            var developer = await _developerRepository.GetByLoginAsync(dto.Username);
            
            if (developer == null || !VerifyPassword(dto.Password, developer.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var developerLogin = new DeveloperLogin
            {
                DeveloperId = developer.Id,
                LoginDate = DateTime.Now,
                IsActive = true,
                IpAddress = dto.IpAdress ?? "LocalHost" // Suponiendo que el DTO incluye esta propiedad
            };

            // Cerrar cualquier sesión activa previa del mismo Developer
            var activeSession = await _developerRepository.GetLoggedInDeveloperAsync(developer.Id);

            if (activeSession != null && !activeSession.IsActive)
            {
                await _developerRepository.CloseActiveSessions(developer.Id);
            }

            //Crea los datos de inicio de sesión en la DB
            await _developerRepository.CreateLoginAsync(developerLogin);
            
            var claims = new List<Claim>
            {
                
                new Claim(ClaimTypes.Name, developer.Login),
                new Claim(ClaimTypes.Role, developer.RoleId.ToString()),
                new Claim("DeveloperId", developer.Id.ToString())
            };

            return _jwtTokenGenerator.GenerateToken(developer.Login, claims);
        }

        public async Task<DeveloperLogin?> GetActiveSessionAsync(int developerId)
        {
            return await _developerRepository.GetLoggedInDeveloperAsync(developerId);
        }

        public async Task<bool> EndSessionAsync(int developerId)
        {
            // Obtener la sesión activa
            var activeSession = await _developerRepository.GetLoggedInDeveloperAsync(developerId);

            if (activeSession == null || !activeSession.IsActive)
            {
                return false; // No hay una sesión activa para cerrar
            }

            // Cerrar la sesión activa
            activeSession.IsActive = false;
            await _developerRepository.CloseActiveSessions(developerId);

            return true;
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var hashedInput = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return hashedInput == hashedPassword;
        }
    }

}

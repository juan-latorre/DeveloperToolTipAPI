using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.AuthDTOs;
using DeveloperToolTip.Application.InterfacesApp;
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

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, developer.Login),
                new Claim(ClaimTypes.Role, developer.RoleId.ToString())
            };

            return _jwtTokenGenerator.GenerateToken(developer.Login, claims);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var hashedInput = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return hashedInput == hashedPassword;
        }
    }

}

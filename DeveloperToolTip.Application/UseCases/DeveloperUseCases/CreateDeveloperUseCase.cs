using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.DeveloperUseCases
{
    public class CreateDeveloperUseCase : ICreateDeveloperUseCase
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IDeveloperRoleRepository _developerRoleRepository;

        public CreateDeveloperUseCase(IDeveloperRepository developerRepository, IDeveloperRoleRepository developerRoleRepository)
        {
            _developerRepository = developerRepository;
            _developerRoleRepository = developerRoleRepository;
        }

        public async Task<int> ExecuteAsync(CreateDeveloperDto dto)
        {
            // Validar que el rol exista
            var role = await _developerRoleRepository.GetByIdAsync(dto.RoleId);
            if (role == null)
            {
                throw new ArgumentException($"Role with ID {dto.RoleId} does not exist.");
            }

            // Encriptar la contraseña usando SHA2_256
            string hashedPassword = HashPassword(dto.Password);

            // Crear la entidad Developer
            var developer = new Developer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Login = dto.Login,
                PasswordHash = hashedPassword,
                RoleId = dto.RoleId,
                IsActive = true
            };

           await _developerRepository.AddAsync(developer);

            return developer.Id;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}

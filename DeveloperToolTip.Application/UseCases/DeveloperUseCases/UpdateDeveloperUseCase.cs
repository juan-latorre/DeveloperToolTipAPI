using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Interfaces;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;

namespace DeveloperToolTip.Application.UseCases.DeveloperUseCases
{
    public class UpdateDeveloperUseCase : IUpdateDeveloperUseCase
    {
        private readonly IDeveloperRepository _developerRepository;

        public UpdateDeveloperUseCase(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task ExecuteAsync(UpdateDeveloperDto dto)
        {
            // Obtener el developer por su Id
            var developer = await _developerRepository.GetByIdAsync(dto.Id);
            if (developer == null)
            {
                throw new KeyNotFoundException($"Developer with Id {dto.Id} not found.");
            }

            // Actualizar los datos del developer
            developer.FirstName = dto.FirstName;
            developer.LastName = dto.LastName;
            developer.Email = dto.Email;
            developer.Login = dto.Login;
            developer.RoleId = dto.RoleId;
            developer.IsActive = dto.IsActive;

            // Actualizar en la base de datos
            await _developerRepository.UpdateAsync(developer);
        }
    }
}

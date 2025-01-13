using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.RoleUseCases
{
    public class UpdateRoleDeveloperUseCase : IUpdateRoleDeveloperUseCase
    {
        private readonly IDeveloperRoleRepository _developerRoleRepository;

        public UpdateRoleDeveloperUseCase(IDeveloperRoleRepository developerRoleRepository)
        {
            _developerRoleRepository = developerRoleRepository;
        }

        public async Task ExecuteAsync(UpdateRoleDeveloperDto dto)
        {
            var rol = await _developerRoleRepository.GetByIdAsync(dto.Id);
            if (rol == null)
            {
                throw new KeyNotFoundException($"Role with Id {dto.Id} not found.");
            }

            rol.RoleName = dto.RoleName;

            await _developerRoleRepository.UpdateAsync(rol);

        }


    }
}

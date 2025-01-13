using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Core.Interfaces;
using DeveloperToolTip.Core.Entities;
namespace DeveloperToolTip.Application.UseCases.RoleUseCases
{
    public class CreateRoleDeveloperUseCase : ICreateRoleDeveloperUseCase
    {
        private readonly IDeveloperRoleRepository _developerRoleRepository;

        public CreateRoleDeveloperUseCase(IDeveloperRoleRepository developerRoleRepository)
        {
            _developerRoleRepository = developerRoleRepository;
        }

        public async Task<int> ExecuteAsync(CreateRoleDeveloperDto dto)
        {
            var rol = new DeveloperRole
            {
                RoleName = dto.RoleName
            };

            await _developerRoleRepository.AddAsync(rol);

            return rol.Id;

        }
    }
}

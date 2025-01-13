using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.RoleUseCases
{
    public class GetRoleDeveloperByIdUseCase : IGetRoleDeveloperByIdUseCase
    {
        private readonly IDeveloperRoleRepository _developerRoleRepository;

        public GetRoleDeveloperByIdUseCase(IDeveloperRoleRepository developerRoleRepository)
        {
            _developerRoleRepository = developerRoleRepository;
        }

        public async Task<DeveloperRoleDto> ExecuteAsync(int id)
        {
            var developerRole = await _developerRoleRepository.GetByIdAsync(id);
            if (developerRole == null)
            {
                throw new KeyNotFoundException($"Role with Id {id} not found.");
            }

            return new DeveloperRoleDto { Id = developerRole.Id, RoleName = developerRole.RoleName };
        }

    }
}

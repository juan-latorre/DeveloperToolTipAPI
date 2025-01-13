using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.RoleUseCases
{
    public class GetAllRolesDeveloperUseCase : IGetAllRolesDeveloperUseCase
    {
        private readonly IDeveloperRoleRepository _developerRoleRepository;

        public GetAllRolesDeveloperUseCase(IDeveloperRoleRepository developerRoleRepository)
        {
            _developerRoleRepository = developerRoleRepository;
        }

        public async Task<IEnumerable<DeveloperRoleDto>> ExecuteAsync()
        {
            var roleDeveloper = await _developerRoleRepository.GetAllAsync();
            return roleDeveloper.Select(x => new DeveloperRoleDto
            {
                Id = x.Id,
                RoleName = x.RoleName
            });
        }
    }
}

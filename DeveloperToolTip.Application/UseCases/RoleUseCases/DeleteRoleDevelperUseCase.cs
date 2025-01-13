using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.RoleUseCases
{
    public class DeleteRoleDevelperUseCase : IDeleteRoleDevelperUseCase
    {
        private readonly IDeveloperRoleRepository _developerRoleRepository;

        public DeleteRoleDevelperUseCase(IDeveloperRoleRepository developerRoleRepository)
        {
            _developerRoleRepository = developerRoleRepository;
        }

        public async Task ExecuteAsync(int rolId)
        {
            var rol = await _developerRoleRepository.GetByIdAsync(rolId);

            if (rol == null)
            {
                throw new KeyNotFoundException($"Rol with Id {rolId} not found.");
            }

            await _developerRoleRepository.DeleteAsync(rolId);

        }
    }
}

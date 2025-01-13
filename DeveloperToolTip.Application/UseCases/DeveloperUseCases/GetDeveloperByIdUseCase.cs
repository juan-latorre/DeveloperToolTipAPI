using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.DeveloperUseCases
{
    public class GetDeveloperByIdUseCase : IGetDeveloperByIdUseCase
    {
        private readonly IDeveloperRepository _developerRepository;

        public GetDeveloperByIdUseCase(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task<DeveloperDto> ExecuteAsync(int id)
        {
            var developer = await _developerRepository.GetByIdAsync(id);

            if (developer == null)
            {
                throw new KeyNotFoundException($"Developer with Id {id} not found.");
            }

            return new DeveloperDto
            {
                Id = developer.Id,
                FirstName = developer.FirstName,
                LastName = developer.LastName,
                Email = developer.Email,
                Login = developer.Login,
                RoleId = developer.RoleId,
                IsActive = developer.IsActive
            };
        }
    }
}

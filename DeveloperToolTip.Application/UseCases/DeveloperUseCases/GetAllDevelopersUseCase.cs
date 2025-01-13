using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.DeveloperUseCases
{
    public class GetAllDevelopersUseCase : IGetAllDevelopersUseCase
    {
        private readonly IDeveloperRepository _developerRepository;

        public GetAllDevelopersUseCase(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task<IEnumerable<DeveloperDto>> ExecuteAsync()
        {
            var developers = await _developerRepository.GetAllAsync();
            return developers.Select(d => new DeveloperDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                IsActive = d.IsActive
            });
        }
    }
}

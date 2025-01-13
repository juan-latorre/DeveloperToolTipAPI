using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.DeveloperUseCases
{
    public class DeleteDeveloperUseCase : IDeleteDeveloperUseCase
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeleteDeveloperUseCase(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task ExecuteAsync(int developerId)
        {
            var developer = await _developerRepository.GetByIdAsync(developerId);
            if (developer == null)
            {
                throw new KeyNotFoundException($"Developer with Id {developerId} not found.");
            }

            await _developerRepository.DeleteAsync(developerId);
        }
    }
}

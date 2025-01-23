using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.AuthDTOs;
using DeveloperToolTip.Core.Entities;

namespace DeveloperToolTip.Application.UseCases.AuthUseCases
{
    public interface IAuthenticateDeveloperUseCase
    {
        Task<string> ExecuteAsync(LoginDto dto);
        Task<DeveloperLogin?> GetActiveSessionAsync(int developerId);
        Task<bool> EndSessionAsync(int developerId);
    
    }
}

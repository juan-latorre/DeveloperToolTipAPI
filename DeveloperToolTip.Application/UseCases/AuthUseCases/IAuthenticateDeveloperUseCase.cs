using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.AuthDTOs;

namespace DeveloperToolTip.Application.UseCases.AuthUseCases
{
    public interface IAuthenticateDeveloperUseCase
    {
        Task<string> ExecuteAsync(LoginDto dto);
    }
}

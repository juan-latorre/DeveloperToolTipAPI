using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.UseCases.RoleUseCases
{
    public interface IDeleteRoleDevelperUseCase
    {
        Task ExecuteAsync(int rolId);
    }
}

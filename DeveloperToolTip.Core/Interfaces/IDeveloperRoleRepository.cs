using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Entities;

namespace DeveloperToolTip.Core.Interfaces
{
    public interface IDeveloperRoleRepository
    {
        Task<IEnumerable<DeveloperRole>> GetAllAsync();
        Task<DeveloperRole> GetByIdAsync(int id);
        Task AddAsync(DeveloperRole developer);
        Task UpdateAsync(DeveloperRole developer);
        Task DeleteAsync(int id);
    }
}

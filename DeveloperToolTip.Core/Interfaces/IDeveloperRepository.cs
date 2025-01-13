using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Entities;

namespace DeveloperToolTip.Core.Interfaces
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllAsync();
        Task<Developer> GetByIdAsync(int id);
        Task AddAsync(Developer developer);
        Task UpdateAsync(Developer developer);
        Task DeleteAsync(int id);
        Task<Developer> GetByLoginAsync(string login);
    }
}

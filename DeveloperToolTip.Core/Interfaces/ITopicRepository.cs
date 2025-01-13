using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Entities;

namespace DeveloperToolTip.Core.Interfaces
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllAsync();
        Task<IEnumerable<Topic>> GetAllWithRelationsAsync();
        Task<Topic> GetByIdWithRelationsAsync(int id);
        Task<Topic> GetByIdAsync(int id);
        Task AddAsync(Topic topic);
        Task UpdateAsync(Topic topic);
        Task DeleteAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Entities;

namespace DeveloperToolTip.Core.Interfaces
{
    public interface ITopicCategoryRepository
    {
        Task<IEnumerable<TopicCategory>> GetAllAsync();
        Task<TopicCategory> GetByIdAsync(int id);
        Task AddAsync(TopicCategory topicCategory);
        Task UpdateAsync(TopicCategory topicCategory);
        Task DeleteAsync(int id);
    }
}

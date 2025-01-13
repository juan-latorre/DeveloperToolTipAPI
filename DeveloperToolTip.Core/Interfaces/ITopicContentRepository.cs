using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Entities;

namespace DeveloperToolTip.Core.Interfaces
{
    public interface ITopicContentRepository
    {
        Task<IEnumerable<TopicContent>> GetAllAsync();
        Task<TopicContent> GetByIdAsync(int id);
        Task AddAsync(TopicContent topicContent);
        Task UpdateAsync(TopicContent topicContent);
        Task DeleteAsync(int id);

        // Nuevos métodos con relaciones
        Task<IEnumerable<TopicContent>> GetAllWithRelationsAsync();
        Task<TopicContent> GetByIdWithRelationsAsync(int id);
    }
}

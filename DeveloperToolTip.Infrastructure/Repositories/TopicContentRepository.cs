using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeveloperToolTip.Infrastructure.Repositories
{
    public class TopicContentRepository : ITopicContentRepository
    {
        private readonly ApplicationDbContext _context;

        public TopicContentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TopicContent topicContent)
        {
            await _context.TopicContent.AddAsync(topicContent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var topicContent = await _context.TopicContent.FindAsync(id);
            if (topicContent != null)
            {
                _context.TopicContent.Remove(topicContent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TopicContent>> GetAllAsync()
        {
            return await _context.TopicContent.ToListAsync();
        }

        public async Task<TopicContent> GetByIdAsync(int id)
        {
            return await _context.TopicContent.FindAsync(id);
        }

        public async Task UpdateAsync(TopicContent topicContent)
        {
            _context.TopicContent.Update(topicContent);
            await _context.SaveChangesAsync();
        }

        // Método GetAllWithRelationsAsync
        public async Task<IEnumerable<TopicContent>> GetAllWithRelationsAsync()
        {
            return await _context.TopicContent
                .Include(tc => tc.Topic) // Incluye la relación con Topic
                .ToListAsync();
        }

        // Método GetByIdWithRelationsAsync
        public async Task<TopicContent> GetByIdWithRelationsAsync(int id)
        {
          return await _context.TopicContent
          .Include(tc => tc.Topic) // Carga explícita de la relación
          .FirstOrDefaultAsync(tc => tc.Id == id);
        }

    }
}

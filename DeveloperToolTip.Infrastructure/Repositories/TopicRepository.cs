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
    public class TopicRepository : ITopicRepository
    {

        private readonly ApplicationDbContext _context;

        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Topic>> GetAllAsync() => 
             await _context.Topics.ToListAsync();

        public async Task<IEnumerable<Topic>> GetAllWithRelationsAsync()
        {
            return await _context.Topics
                .Include(t => t.Category) // Incluye la categoría
                .Include(t => t.Creator)  // Incluye el creador
                .ToListAsync();
        }
        public async Task<Topic> GetByIdWithRelationsAsync(int id)
        {
            return await _context.Topics
                .Include(t => t.Category)  // Incluye la relación con TopicCategory
                .Include(t => t.Creator)   // Incluye la relación con Developer (creador)
                .FirstOrDefaultAsync(t => t.Id == id); // Busca por ID
        }

        public async Task<Topic> GetByIdAsync(int id) =>
            await _context.Topics.FindAsync(id);

        public async Task AddAsync(Topic topic) 
        {
           await _context.Topics.AddAsync(topic);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Topic topic)
        { 
         _context.Topics.Update(topic);
         await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic != null) 
            {
             _context.Topics.Remove(topic);
             await _context.SaveChangesAsync();
            }
        }

    }
}

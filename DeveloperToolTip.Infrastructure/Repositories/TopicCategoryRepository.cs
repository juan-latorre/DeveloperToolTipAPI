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
    public class TopicCategoryRepository : ITopicCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public TopicCategoryRepository(ApplicationDbContext context) 
        {
          _context = context;
        }

         public async Task<IEnumerable<TopicCategory>> GetAllAsync() => 
            await _context.TopicCategories.ToListAsync();

        public async Task<TopicCategory> GetByIdAsync(int id) =>
            await _context.TopicCategories.FindAsync(id);

        public async Task AddAsync(TopicCategory category) { 
        
            await _context.TopicCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TopicCategory category) 
        {
         _context.TopicCategories.Update(category);
         await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) 
        {
            var category = await _context.TopicCategories.FindAsync(id);
            if (category != null) 
            {
                _context.TopicCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        
        }

    }
}

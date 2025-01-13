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
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ApplicationDbContext _context;

        public DeveloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Developer>> GetAllAsync() =>
            await _context.Developers.ToListAsync();

        public async Task<Developer> GetByIdAsync(int id) =>
            await _context.Developers.FindAsync(id);

        public async Task AddAsync(Developer developer)
        {
            await _context.Developers.AddAsync(developer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Developer developer)
        {
            _context.Developers.Update(developer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var developer = await _context.Developers.FindAsync(id);
            if (developer != null)
            {
                _context.Developers.Remove(developer);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Developer> GetByLoginAsync(string login)
        {
            return await _context.Developers.FirstOrDefaultAsync(d => d.Login == login);
        }
    }
}

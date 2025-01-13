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
    public class DeveloperRoleRepository : IDeveloperRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public DeveloperRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DeveloperRole>> GetAllAsync()
        {
            return await _context.DeveloperRoles.ToListAsync();
        }

        public async Task<DeveloperRole> GetByIdAsync(int id)
        {
            return await _context.DeveloperRoles.FindAsync(id);
        }

        public async Task AddAsync(DeveloperRole role)
        {
            await _context.DeveloperRoles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DeveloperRole role)
        {
            _context.DeveloperRoles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var role = await _context.DeveloperRoles.FindAsync(id);
            if (role != null)
            {
                _context.DeveloperRoles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}

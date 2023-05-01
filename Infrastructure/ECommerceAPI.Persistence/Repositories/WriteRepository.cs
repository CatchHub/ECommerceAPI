using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class WriteRepository<EntityT> : IWriteRepository<EntityT> where EntityT : BaseEntity
    {
        readonly private ECommerceAPIDbContext _context;

        public WriteRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<EntityT> Table => _context.Set<EntityT>();

        public async Task<bool> AddAsync(EntityT model)
        {
            EntityEntry<EntityT> entityEntry = await Table.AddAsync(model);
            return entityEntry.State  == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<EntityT> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }
        public bool Remove(EntityT data)
        {
            EntityEntry<EntityT> entityEntry  = Table.Remove(data);
            return entityEntry.State == EntityState.Deleted; 
        }
        public async Task<bool> RemoveAsync(string id)
        {
            EntityT model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return this.Remove(model);
        }
        public bool RemoveRange(List<EntityT> data)
        {
            Table.RemoveRange(data);
            return true;
        }
        public bool Update(EntityT model)
        {
            EntityEntry entityEntry =  Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

    }
}

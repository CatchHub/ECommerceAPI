using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class ReadRepository<EntityT> : IReadRepository<EntityT> where EntityT: BaseEntity
    {
        readonly private ECommerceAPIDbContext _context;

        public ReadRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<EntityT> Table => _context.Set<EntityT>();

        public IQueryable<EntityT> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking(); 
            return query;
        }
    
        public IQueryable<EntityT> GetWhere(System.Linq.Expressions.Expression<Func<EntityT, bool>> predicate, bool tracking = true)
        {
            var query = Table.Where(predicate);
            if(!tracking)
                query = query.AsNoTracking();
            return query;

        }
        public async Task<EntityT> GetSingleAsync(System.Linq.Expressions.Expression<Func<EntityT, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(predicate);

        }

        public async Task<EntityT> GetByIdAsync(string id, bool tracking = true)
        //=>await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data=>data.Id ==Guid.Parse(id));

        }

    }
}
 
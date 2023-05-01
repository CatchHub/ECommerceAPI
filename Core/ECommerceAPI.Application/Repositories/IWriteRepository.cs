using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface  IWriteRepository<EntityT> : IRepository<EntityT> where EntityT : BaseEntity
    {
        Task<bool> AddAsync(EntityT model);
        Task<bool> AddRangeAsync(List<EntityT> data);
        bool Remove(EntityT model);
        Task<bool> RemoveAsync(string id);
        bool RemoveRange(List<EntityT> data);
        bool Update(EntityT model);
        Task<int> SaveAsync();
    }
}

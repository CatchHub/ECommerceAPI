using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IReadRepository<EntityT> : IRepository<EntityT> where EntityT : BaseEntity
    {
        IQueryable<EntityT> GetAll(bool tracking = true);

        IQueryable<EntityT> GetWhere(Expression<Func<EntityT, bool>> predicate, bool tracking = true);

        Task<EntityT> GetSingleAsync(Expression<Func<EntityT, bool>> predicate, bool tracking = true);

        Task<EntityT> GetByIdAsync(string id, bool tracking = true);

    }
}

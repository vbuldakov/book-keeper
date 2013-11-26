using Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Core.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All(ISpecification<TEntity> specification = null);
    }
}

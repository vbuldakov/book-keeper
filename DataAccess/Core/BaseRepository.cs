using Domain.Core.Repositories;
using Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataAccess.Core
{
    public abstract class BaseRepository<TEntity> : 
        ICreateRepository<TEntity>,
        IReadRepository<TEntity>, 
        IUpdateRepository,
        IDeleteRepository<TEntity> where TEntity : class
    {
        private readonly IDbSet<TEntity> _dbSet;

        public BaseRepository(IDbContextAdapter dbAdapter)
        {
            _dbSet = dbAdapter.GetDbSet<TEntity>();
        }

        public virtual IEnumerable<TEntity> All(ISpecification<TEntity> specification = null)
        {
            if (specification != null)
            {
                return _dbSet.Where(specification.SatisfiedBy());
            }

            return _dbSet;
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        protected IQueryable<TEntity> AsQueryable()
        {
            return _dbSet;
        }
    }
}

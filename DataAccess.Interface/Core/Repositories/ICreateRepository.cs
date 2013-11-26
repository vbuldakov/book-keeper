using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Core.Repositories
{
    public interface ICreateRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
    }
}

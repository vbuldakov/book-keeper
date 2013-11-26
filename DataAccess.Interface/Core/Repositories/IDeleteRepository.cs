using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Core.Repositories
{
    public interface IDeleteRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityt);
    }
}

using Domain.Core.Repositories;
using Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Expences
{
    public interface IExpenceCategoryRepository :
        IReadRepository<ExpenceCategory>
    {
        IEnumerable<ExpenceCategory> GetCategoriesForUser(ISpecification<ExpenceCategory> spec);
    }
}

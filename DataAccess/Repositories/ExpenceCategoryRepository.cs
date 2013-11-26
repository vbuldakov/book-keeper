using DataAccess.Core;
using Domain.Core.Specification;
using Domain.Expences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ExpenceCategoryRepository : BaseRepository<ExpenceCategory>, IExpenceCategoryRepository
    {
        public ExpenceCategoryRepository(IDbContextAdapter contextAdapter) : base(contextAdapter)
        {
        }

        public IEnumerable<ExpenceCategory> GetCategoriesForUser(ISpecification<ExpenceCategory> spec)
        {
            return this.AsQueryable()
                    .Where(spec.SatisfiedBy())
                    .OrderBy(c => c.Name);
        }
    }
}

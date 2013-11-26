using DataAccess.Core;
using Domain.Core.Specification;
using Domain.Expences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class ExpenceRepository : BaseRepository<Expence>, IExpenceRepository
    {
        public ExpenceRepository(IDbContextAdapter adapter) : base(adapter)
        {

        }

        public int Count(ISpecification<Expence> spec)
        {
            return this.AsQueryable()
                .Where(spec.SatisfiedBy())
                .Count();
        }

        public IEnumerable<Expence> GetUserExpences(ISpecification<Expence> spec, int skip, int take)
        {
            return this.AsQueryable()
                .Where(spec.SatisfiedBy())
                .OrderByDescending(e => e.Date)
                .Skip(skip)
                .Take(take)
                .Include("Category")
                .ToList();

        }
    }
}

using DataAccess.Core;
using Domain.Core.Specification;
using Domain.Expences;
using Domain.Statistics;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly IDbSet<Expence> _expencesSet;

        public StatisticsRepository(IDbContextAdapter dbAdapter)
        {
            _expencesSet = dbAdapter.GetDbSet<Expence>();
        }
        public Summary GetSummary(ISpecification<Expence> spec)
        {
            double total =
                _expencesSet
                    .Where(spec.SatisfiedBy())
                    .Sum(e => e.Total);

            return new Summary(total);
        }


        public IEnumerable<CategorySummary> GetCategoriesRating(ISpecification<Expence> spec)
        {
            return 
                _expencesSet
                    .Where(spec.SatisfiedBy())
                    .GroupBy(e => e.Category)
                    .Select(g =>
                        new CategorySummary
                        {
                            CategoryName = g.Key.Name,
                            Total = g.Sum(e => e.Total),
                            ExpencesCount = g.Count()
                        })
                    .OrderByDescending(cs => cs.Total)
                    .ToList();
        }
    }
}

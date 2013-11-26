using Domain.Core.Specification;
using Domain.Expences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Statistics
{
    public interface IStatisticsRepository
    {
        Summary GetSummary(ISpecification<Expence> spec);
        IEnumerable<CategorySummary> GetCategoriesRating(ISpecification<Expence> spec);
    }
}

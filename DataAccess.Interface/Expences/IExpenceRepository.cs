using Domain.Core.Repositories;
using Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Expences
{
    public interface IExpenceRepository :
        IReadRepository<Expence>
    {
        IEnumerable<Expence> GetUserExpences(ISpecification<Expence> spec, int skip, int take);
    }
}

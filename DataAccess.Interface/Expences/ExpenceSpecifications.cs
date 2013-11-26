using Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Expences
{
    public static class ExpenceSpecifications
    {
        public static ISpecification<Expence> ByUserId(int userId)
        {
            return new DirectSpecification<Expence>(e => e.Category.UserId == userId);
        }
    }
}

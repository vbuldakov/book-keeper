using Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Expences
{
    public static class ExpenceSpecifications
    {
        public static ISpecification<Expence> ByUserAndId(int userId, int expenceId)
        {
            return new AndSpecification<Expence>(ByUserId(userId), ById(expenceId));
        }

        public static ISpecification<Expence> ByUserId(int userId)
        {
            return new DirectSpecification<Expence>(e => e.Category.UserId == userId);
        }

        public static ISpecification<Expence> ById(int id)
        {
            return new DirectSpecification<Expence>(e => e.ExpenceId == id);
        }

        public static ISpecification<Expence> DateFilter(DateTime from, DateTime to)
        {
            return new DirectSpecification<Expence>(e => e.Date >= from && e.Date <= to);
        }
    }
}

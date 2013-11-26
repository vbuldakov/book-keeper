using Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Expences
{
    public static class ExpenceCategorySpecifications
    {
        public static ISpecification<ExpenceCategory> ByUserId(int userId)
        {
            return new DirectSpecification<ExpenceCategory>(c => c.UserId == userId);
        }

        public static ISpecification<ExpenceCategory> ById(int id)
        {
            return new DirectSpecification<ExpenceCategory>(c => c.ExpenceCategoryId == id);
        }

        public static ISpecification<ExpenceCategory> ByName(string name)
        {
            return new DirectSpecification<ExpenceCategory>(c => c.Name == name);
        }

    }
}

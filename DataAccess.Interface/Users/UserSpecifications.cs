using Domain.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public static class UserSpecifications
    {
        public static ISpecification<User> ById(int userId)
        {
            return new DirectSpecification<User>(u => u.UserId == userId);
        }

        public static ISpecification<User> ByEmail(string email)
        {
            return new DirectSpecification<User>(u => u.Email == email);
        }

    }
}

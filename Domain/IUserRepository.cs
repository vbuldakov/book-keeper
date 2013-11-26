using Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public interface IUserRepository :
        IReadRepository<User>
    {
    }
}

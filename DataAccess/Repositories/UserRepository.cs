using DataAccess.Core;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbContextAdapter adapter) : base(adapter)
        {

        }
    }
}

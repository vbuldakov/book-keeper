using Domain.Core;
using System;

namespace DataAccess.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextAdapter _contextAdapter;

        public UnitOfWork(IDbContextAdapter contextAdapter)
        {
            _contextAdapter = contextAdapter;
        }

        #region IUnitOfWork Members

        public void Commit()
        {
            _contextAdapter.SaveChanges();
        }

        #endregion
    }
}
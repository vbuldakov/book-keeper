using System.Data;
using System.Data.Entity;

namespace DataAccess.Core
{
    public class DbContextAdapter : IDbContextAdapter
    {
        private readonly DbContext _context;

        public DbContextAdapter(DbContext context)
        {
            _context = context;
        }

        #region Implementation of IDbContextAdapter

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
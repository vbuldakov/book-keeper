using System.Data.Entity;

namespace DataAccess.Core
{
    public interface IDbContextAdapter
    {
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
        void SaveChanges();
    }
}

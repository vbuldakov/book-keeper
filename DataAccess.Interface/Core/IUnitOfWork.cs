namespace Domain.Core
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
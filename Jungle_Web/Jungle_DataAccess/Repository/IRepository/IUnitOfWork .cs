namespace Jungle_DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}

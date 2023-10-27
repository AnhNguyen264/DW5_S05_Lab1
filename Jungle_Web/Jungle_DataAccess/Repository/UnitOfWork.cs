using Jungle_DataAccess.Data;
using Jungle_DataAccess.Repository.IRepository;

namespace Jungle_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JungleDbContext _dbContext;
        public UnitOfWork(JungleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

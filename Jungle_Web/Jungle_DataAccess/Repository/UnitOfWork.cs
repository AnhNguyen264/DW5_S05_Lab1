using Jungle_DataAccess.Data;
using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JungleDbContext _dbContext;
        public UnitOfWork(JungleDbContext dbContext)
        {
            _dbContext = dbContext;
            Country = new CountryRepository(dbContext);
            Destination= new DestinationRepository(dbContext);
            Guide= new GuideRepository(dbContext);
            Travel= new TravelRepository(dbContext);
            TravelRecommendation= new TravelRecommendationRepository(dbContext);
        }

        public ICountryRepository Country  {get; private set; }

        public IDestinationRepository Destination { get; private set; }

        public IGuideRepository Guide { get; private set; }

        public ITravelRepository Travel { get; private set; }

        public ITravelRecommendationRepository TravelRecommendation { get; private set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

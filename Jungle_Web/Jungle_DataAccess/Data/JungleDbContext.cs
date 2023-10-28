using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Jungle_DataAccess.Data
{
    public class JungleDbContext:DbContext
    {
       

        DbSet<Country> countries { get; set; }
        DbSet<Destination> destinations { get; set; }
        DbSet<Travel> travels { get; set; }
        DbSet<TravelRecommendation> travelRecommendations { get; set; }
        DbSet<Guide> guides { get; set; }

        public JungleDbContext(DbContextOptions<JungleDbContext> options) : base(options)
        { }
    }
}

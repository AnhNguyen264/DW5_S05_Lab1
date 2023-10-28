using Jungle_DataAccess.Data;
using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly JungleDbContext _db;
        public ReservationRepository(JungleDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Reservation reservation)
        {
            _db.Update(reservation);
        }

        //public new void Add(ReservationRepository entity)
        //{
        //    var travelDepartureDate = _db.Travels
        //        .Where(t => t.Id == entity.TravelId)
        //        .Select(t => t.DepartureDate)
        //        .FirstOrDefault();

        //    if (travelDepartureDate > DateTime.Now)
        //    {
        //        base.Add(entity);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Impossible de réserver un voyage dont le départ est aujourd'hui ou dans le passé.");
        //    }
        //}


    }
 }

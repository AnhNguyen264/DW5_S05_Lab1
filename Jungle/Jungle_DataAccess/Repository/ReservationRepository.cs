using Jungle_DataAccess.Data;
using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void Add(Reservation entity)
        {
            var travel = _db.Travels.FirstOrDefault(t => t.Id == entity.TravelId);

            if (travel == null)
            {
                throw new InvalidOperationException("Les voyages n'existent pas.");
            }
            // Calculer le nombre de places disponibles au départ
            int placesDisponibles = travel.availablePlace;
            // Obtenir toutes les réservations existantes pour le même voyage
            var reservationsExistantes = _db.Reservations.Where(r => r.TravelId == entity.TravelId);

            // Calculer le nombre total de personnes  dans les réservations existantes
            int nbPersonnesTravel = reservationsExistantes.Sum(r => r.NbsPersonnes);

            // Calculer le nombre total de personnes dans la réservation en cours
            int nbPersonnesReservationCourante = entity.NbsPersonnes;

            // Vérifier si le nombre total de personnes dans toutes les réservations dépasse le nombre de places disponibles.
            if ( ( nbPersonnesTravel + nbPersonnesReservationCourante ) > placesDisponibles)
            {
                throw new InvalidOperationException("Vous ne pouvez pas réserver pour plus de personnes qu'il n'y a de places disponibles.");
            }
            if (travel.DepartureDate <= DateTime.Now)
            {
                throw new InvalidOperationException("Impossible de réserver un voyage dont le départ est aujourd'hui ou dans le passé.");

            }
            var daysUntilDeparture = (travel.DepartureDate - DateTime.Now).Days;
            if(daysUntilDeparture <=14 )
            {
                var originalPrice = travel.Price;
                entity.PriceFinal = 0.85 * originalPrice;
            }
            _db.Reservations.Add(entity);
        }

    
        public Reservation Get(int id)
        {
            return _db.Reservations.Find(id);
        }

        public IEnumerable<Reservation> GetAll(
            Expression<Func<Reservation, bool>> filter = null,
            Func<IQueryable<Reservation>, IOrderedQueryable<Reservation>> orderBy = null,
            string includeProperties = null,
            bool isTracking = true)
        {
            IQueryable<Reservation> query = _db.Reservations;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public Reservation FirstOrDefault(
            Expression<Func<Reservation, bool>> filter = null,
            string includeProperties = null,
            bool isTracking = true)
        {
            IQueryable<Reservation> query = _db.Reservations;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

   

        public void Remove(Reservation entity)
        {
            _db.Reservations.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Reservation> entity)
        {
            _db.Reservations.RemoveRange(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_Models.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateReservation { get; set; }

       //public double PriceFinal { get; set; }

        public int NbsPersonnes { get; set; }

        public bool IsConfirmed { get; set; }

        //public List<String> Opstions { get; set; }

        public int TravelId { get; set; }

        public Travel Travel { get; set; }




    }
}

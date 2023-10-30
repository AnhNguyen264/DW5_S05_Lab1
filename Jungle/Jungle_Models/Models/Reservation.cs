using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jungle_Models.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateReservation { get; set; }

        public double PriceFinal { get; set; }

        public int NbsPersonnes { get; set; }

        public bool IsConfirmed { get; set; }

        [ForeignKey(nameof(Travel))]
        public int TravelId { get; set; }

        [ValidateNever]
        public Travel Travel { get; set; }

        [ValidateNever]
        public virtual List<Option>? Options { get; set; }
    }
}

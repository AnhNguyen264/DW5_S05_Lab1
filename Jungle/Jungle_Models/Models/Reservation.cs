using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jungle_Models.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateReservation { get; set; }

        public double PriceFinal { get; set; }

        [Range(1,10)]
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

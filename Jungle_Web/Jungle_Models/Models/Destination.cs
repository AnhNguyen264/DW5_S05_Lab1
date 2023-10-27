using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jungle_Models.Models
{
    public class Destination
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        [ValidateNever]
        public virtual Country Country { get; set; }


        [ValidateNever]
        public virtual List<Travel> Travels { get; set; }
    }
}

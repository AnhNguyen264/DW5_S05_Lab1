using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jungle_Models.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DepartureDate { get; set; }
        public int Duration { get; set; }

        [ForeignKey(nameof(Destination))]
        public int DestinationId { get; set; }

        [ValidateNever]
        public virtual Destination Destination { get; set; }



        [ForeignKey(nameof(TravelRecommendation))]
        public int? TravelRecommendationId { get; set; }

        [ValidateNever]
        public virtual TravelRecommendation? TravelRecommendation { get; set; }


        [ForeignKey(nameof(Guide))]
        public int? GuideId { get; set; }
        [ValidateNever]
        public virtual Guide? Guide { get; set; }
    }
}

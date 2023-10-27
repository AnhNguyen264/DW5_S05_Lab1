using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jungle_Models.Models
{
    public class TravelRecommendation
    {
        [Key]
        public int Id { get; set; }
      public string DangerLevel { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(Travel))]
        public int TravelId { get; set; }

        [ValidateNever]
        public virtual Travel Travel { get; set; }


    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Jungle_Models.Models
{
    public class Guide
    {
        [Key]
        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Speciality { get; set; }


        [ValidateNever]
        public virtual List<Travel>? Travels { get; set; }
    }
}

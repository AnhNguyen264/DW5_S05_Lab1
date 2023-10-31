using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_Models.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Description { get; set; }

        public double Prix { get; set; }

        [ValidateNever]
        public virtual List<Travel>? Travels { get; set; }

        [ValidateNever]
        public virtual List<Reservation>? Reservations { get; set; }
    }
}

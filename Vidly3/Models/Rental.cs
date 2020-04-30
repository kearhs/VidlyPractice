using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly3.Models
{
    public class Rental
    {
        [Required]
        [Display(Name = "Rental Id")]
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Display(Name = "Date Rented")]
        public DateTime DateRented { get; set; }

        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }
    }
}
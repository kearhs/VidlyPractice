using System.ComponentModel.DataAnnotations;

namespace Vidly3.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
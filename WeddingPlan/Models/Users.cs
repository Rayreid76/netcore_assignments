using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlan.Models
{
    public class WeddingGoer
    {
        [Key]
        public int Id {get; set;}
        [Required]
        [MinLength(3, ErrorMessage = "Too Short")]
        [Display(Name = "First Name:")]
        public string FirstName {get; set;}
        [Required]
        [MinLength(3, ErrorMessage = "Too Short")]
        [Display(Name = "Last Name:")]
        public string LastName {get; set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password {get; set;}
        [Compare("Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Display(Name = "Confirm Password:")]
        public string Confirm {get; set;}
    }
    public class LoginUser
    {
        [Required]        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        public string Email {get; set;}
        [Required]        
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password is to short, need 8 characters")]
        [Display(Name = "Password:")]
        public string Password {get; set;}
    }
}
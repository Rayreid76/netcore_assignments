using System.ComponentModel.DataAnnotations;
namespace ReviewRest.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        [Display(Name = "Name:")]
        public string Name {get; set;}
        [Required]
        [Display(Name = "Restaurant:")]
        public string Restaurant {get; set;}
        [Required]
        [Display(Name = "Comments:")]
        [MinLength(8, ErrorMessage = "The Review was not long enough.")]
        [DataType(DataType.Text)]
        public string Comments {get; set;}
        [Required]
        [Display(Name = "Date:")]
        [DataType(DataType.Date)]
        public string Date {get; set;}
        [Required]
        [Display(Name = "Star:")]
        [Range(1, 5)]
        public int Star {get; set;}
    }
}
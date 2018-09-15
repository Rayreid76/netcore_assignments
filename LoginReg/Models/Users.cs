using System;
using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models
{
    public class Users
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        [MinLength(2, ErrorMessage = "Your Name is way to short!")]
        public string FirstName {get; set;}
        [Required]
        [MinLength(2, ErrorMessage = "Your Name is way to short!")]
        public string LastName  {get; set;}
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address!")]
        public string Email  {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Way to short!")]
        public string Password  {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Does not match!")]
        public string ConfirmPassword  {get; set;}
        public DateTime Created_at {get; set;}
        public DateTime Updated_at {get; set;}
    }
}
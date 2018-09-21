using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class Person
    {
        [Key]
        public int UserId {get; set;}
        [Required]
        [MinLength(3, ErrorMessage = "Needs to be longer than 3 characters")]
        [Display(Name = "First Name:")]
        public string FirstName {get; set;}
        [Required]
        [MinLength(3, ErrorMessage = "Needs to be longer than 3 characters")]
        [Display(Name = "Last Name:")]
        public string LastName {get; set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email:")]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password is to short, need 8 characters")]
        [Display(Name = "Password:")]
        public string Password {get; set;}
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password:")]
        [NotMapped]
        public string Confirm {get; set;}
        public DateTime Created_at {get; set;}
        public DateTime Updated_at {get; set;}
        public IEnumerable<Accounts> Accounts {get; set;}
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
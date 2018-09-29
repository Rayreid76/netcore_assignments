using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlan.Models
{
    public class Planner
    {
        [Key]
        public int Id {get; set;}
        [Required]
        [MinLength(3, ErrorMessage = "Too Short")]
        public string Groom {get; set;}
        [Required]
        [MinLength(3, ErrorMessage = "Too Short")]
        public string Bride {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime Date {get; set;}
        [Required]        
        public string Address {get; set;}
        public int UsersId {get; set;}
        public IEnumerable<Response> Response {get; set;}
    }
    public class Response
    {
        public int Id {get; set;}
        public int UsersId {get; set;}
        public int PlannerId {get; set;}
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(!(value is DateTime))
                return new ValidationResult("Not a valid date");
                
            DateTime date = Convert.ToDateTime(value);

            if(date < DateTime.Now)
                return new ValidationResult("Date must be in the future!");

            return ValidationResult.Success;
        }
    }
}
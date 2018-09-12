using System.ComponentModel.DataAnnotations;

namespace REATauranter.Models
{
    public class Reviews{
        [Required]
        public string name {get; set;}
        [Required]
        public string restaurant {get; set;}
        [Required]
        [MinLength(10, ErrorMessage = "Review is to short")]
        public string review {get; set;}
        [Required]
        [DataType(DataType.Date)]
        public string dateofvisit {get; set;}
        [Required]
        [Range(1, 5)]
        public int stars {get; set;}
    }
}
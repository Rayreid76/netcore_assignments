using System;
using System.ComponentModel.DataAnnotations;

namespace WalkintheWoods.Models
{
    public class Trails
    {
        [Required]
        [MinLength(4, ErrorMessage = "Not reached minimum length")]
        public string Name {get;set;}
        [Required]
        [DataType(DataType.Text)]
        [MinLength(10, ErrorMessage = "Not reached minimum length")]
        public string Discription {get;set;}
        [Required]
        [Range(0, Int16.MaxValue, ErrorMessage = "No Negative Numbers")]
        public double Miles {get;set;}
        [Required]
        [Range(-282, Int16.MaxValue, ErrorMessage = "Trail has to between the elevation ot Death Valley and Mount Everest")]
        public int Elevation {get; set;}
        [Required]
        [Range(-180, 180, ErrorMessage = "Range -180 to 180")]
        public double Longitude {get; set;}
        [Required]
        [Range(-90, 90, ErrorMessage = "Range -90 to 90")]
        public double Latitude {get; set;}

    }
}
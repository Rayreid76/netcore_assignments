using System;

namespace Products.Models
{
    public class Product
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public double Price {get;set;}
        public DateTime Created_at {get; set;} = DateTime.Now;
        public DateTime Updated_at {get; set;} = DateTime.Now;

    }
}
using System;

namespace Products.Models
{
    public class Category
    {
        public int Id {get; set;}
        public string NameCategories {get; set;}
        public DateTime Created_at {get; set;} = DateTime.Now;
        public DateTime Update_at {get; set;} = DateTime.Now;
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class Accounts
    {
        [Key]
        public int AccountsId {get; set;}
        public double transaction {get; set;}
        public DateTime Created_at {get; set;} = DateTime.Now;
        public DateTime Updated_at {get; set;} = DateTime.Now;
        public Person Registure {get; set;}
    }
}
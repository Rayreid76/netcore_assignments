using System;

namespace Bank.Models
{
    public class Accounts
    {
        public int AccountsId {get; set;}
        public double transaction {get; set;}
        public DateTime Created_at {get; set;}
        public DateTime Updated_at {get; set;}
        public User Registure {get; set;}
    }
}
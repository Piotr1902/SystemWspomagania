using System.Collections.Generic;

namespace SystemWspomagania.API.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string Address { get; set; } 
        public int PhoneNr { get; set; }
        public ICollection<Soldier> Soldiers { get; set; }
    }
}
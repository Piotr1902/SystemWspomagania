using System.Collections.Generic;

namespace SystemWspomagania.API.Models
{
    public class Soldier
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Usersurname { get; set; } 
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Pesel { get; set; }
        public int PhoneNr { get; set; }
        public ICollection <Leave> Leaves { get; set; }
        public ICollection <Weapon> Weapons { get; set; }
        public Company Company { get; set; }
        public int? CompanyId { get; set; }

    }
}
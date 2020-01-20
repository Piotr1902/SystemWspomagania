using System;

namespace SystemWspomagania.API.Models
{
    public class IssueWeapon
    {
        public int Id { get; set; }
        public DateTime DateIssue { get; set;}
        public DateTime DateReturn { get; set; }   
        public String Stan { get; set; }
        public Weapon Weapon { get; set; }
        public int WeaponId { get; set; }
    }
}
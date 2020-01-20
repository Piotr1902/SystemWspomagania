using System;

namespace SystemWspomagania.API.Dtos
{
    public class IssueWeaponWeaponSoldierDto
    {
        public int Id { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime DateReturn { get; set; }
        public int WeaponId { get; set; }
        public string WeaponName { get; set;}
        public string SoldierName { get; set; }
    }
}
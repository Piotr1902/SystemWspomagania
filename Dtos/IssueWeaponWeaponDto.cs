using System;

namespace SystemWspomagania.API.Dtos
{
    public class IssueWeaponWeaponDto
    {
        public int Id { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime DateReturn { get; set; }
        public string Stan { get; set;}
        public int WeaponId { get; set; }

    }
}
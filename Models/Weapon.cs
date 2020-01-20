using System.Collections.Generic;

namespace SystemWspomagania.API.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Seria { get; set;}
        public Soldier Soldier { get; set; }
        public int SoldierId { get; set; }
        public ICollection <IssueWeapon> IssueWeapons { get; set; }
    }
}
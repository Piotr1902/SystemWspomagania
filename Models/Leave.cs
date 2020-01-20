using System;

namespace SystemWspomagania.API.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public DateTime DateLeave { get; set; }
        public DateTime DateReturn { get; set; }
        public string Where { get; set;}
        public string Annotation { get; set; }
        public string Typ { get; set; }
        public Soldier Soldier { get; set; }
        public int SoldierId { get; set; }
    }
}
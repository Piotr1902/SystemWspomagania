using System;

namespace SystemWspomagania.API.Dtos
{
    public class LeaveSoldierDto
    {
        public int Id { get; set; }
        public DateTime DateLeave { get; set; }
        public DateTime DateReturn { get; set; }
        public int SoldierId { get; set; }
        public string SoldierName { get; set; }
        public string Where { get; set; }
        public string Annotation { get; set; }
        public string Typ { get; set; }
    }
}
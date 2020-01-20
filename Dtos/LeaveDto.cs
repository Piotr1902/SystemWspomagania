using System;

namespace SystemWspomagania.API.Dtos
{
    public class LeaveDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateLeave { get; set; }
        public DateTime DateReturn { get; set; }
        public string Where { get; set; }
        public string Typ { get; set; }
        public string Annotation { get; set; }
    }
}
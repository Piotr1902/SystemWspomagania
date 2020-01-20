using System.ComponentModel.DataAnnotations;

namespace SystemWspomagania.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Twoje hasło musi mieć od 4 do 8 znaków")]
        public string Password { get; set; }
       
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public long Pesel { get; set; }
       
        public int PhoneNr { get; set; }
       
        public int? CompanyId { get; set; }
    }
}
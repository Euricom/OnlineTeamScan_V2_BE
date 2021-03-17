using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Achternaam is verplicht")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is verplicht")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.UserControllers
{
    public class LoginController
    {
        [Required(ErrorMessage = "Nu ati introdus numele de utilizator.")]
        public String Username { get; set; } = String.Empty;

        [Required(ErrorMessage = "Nu ati introdus parola.")]
        public String Password { get; set; } = String.Empty;

        [Range(typeof(bool), "true", "true", ErrorMessage = "Combinatia utilizator\\parola nu exista.")]
        public Boolean isPasswordValid { get; set; }

        public void CheckPassword(String RetrievedPassword)
        {
            isPasswordValid = RetrievedPassword == Password;
        }

    }
}

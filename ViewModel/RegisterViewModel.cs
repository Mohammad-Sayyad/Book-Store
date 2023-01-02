using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Please enter username or Gmail")]
        [Remote("CheckNameUser", "Account" , ErrorMessage = "username exists, choose another one")]
        public string username { get; set; }
        [Required(ErrorMessage ="Please enter password")]
        public string password { get; set; }
        [Compare("password" , ErrorMessage ="Password is not match")]
        public string repassword { get; set; }

        public string firstname { get; set; }
        public string lastname { get; set; }
        public bool rememberme { get; set; }

        public bool gender { get; set; }
    }
}

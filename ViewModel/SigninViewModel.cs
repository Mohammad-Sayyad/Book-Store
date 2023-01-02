using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class SigninViewModel
    {
        [Required(ErrorMessage ="mandatory")]
        public string username { get; set; }
        public string password { get; set; }
        public bool rememberme { get; set; }


    }
}

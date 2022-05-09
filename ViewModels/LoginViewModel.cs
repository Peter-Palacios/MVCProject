using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class LoginViewModel 
    {
        [Required(ErrorMessage ="Please enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please enter Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

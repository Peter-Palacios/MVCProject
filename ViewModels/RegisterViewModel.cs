using System.ComponentModel.DataAnnotations;
namespace MVCProject.ViewModels
{
    public class RegisterViewModel:LoginViewModel
    {
        [Required(ErrorMessage = "Please add first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please add last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please add phone number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please add email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

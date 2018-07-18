using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SampleCodeFirstIn.Models
{
    public class LoginViewModel
    {
        //[Required]
        //[Remote("IsUserNameExist", "Account", ErrorMessage = "Username Not Found")]
        //[Display(Name = "Username")]
        //public string UserName { get; set; }


        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }
}
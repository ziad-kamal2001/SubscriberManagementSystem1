using SubscriberManagementSystem.Data.Resources;
using System.ComponentModel.DataAnnotations;

namespace SubscriberManagementSystem.Web.ViewModel.Auth
{
    public class LoginViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string Email { get; set;}


		[Display(Name = "Password", ResourceType = typeof(Messages))]
		[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
		public string Password { get; set;}

        public string? ReturnUrl { get; set; }

        //public bool RememberMe { get; set; }
    }
}

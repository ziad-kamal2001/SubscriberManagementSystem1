using SubscriberManagementSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SubscriberManagementSystem.Web.ViewModel.User
{
    public class IndexUserVM
    {
        public List<UserType> UserTypes { get; set; }
        public List<Constant> Genders { get; set; }
    }
}

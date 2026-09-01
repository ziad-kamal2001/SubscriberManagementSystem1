using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Infrastructure.Services.Users.Dto;

namespace SubscriberManagementSystem.Web.ViewModel.User
{
    public class MyProfileVM
    {
        public MyProfileDto MyProfileDto { get; set; }
        public List<Constant> Genders { get; set; }
    }
}

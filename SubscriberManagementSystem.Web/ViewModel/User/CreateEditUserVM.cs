using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Infrastructure.Services.Users.Dto;

namespace SubscriberManagementSystem.Web.ViewModel.User
{
    public class CreateEditUserVM
    {
        public UserDto User { get; set; }
        public List<UserType> UserTypes { get; set; }
        public List<Constant> Genders { get; set; }
    }
}

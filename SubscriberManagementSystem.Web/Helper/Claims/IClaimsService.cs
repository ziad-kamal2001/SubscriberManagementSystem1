using SubscriberManagementSystem.Data.Models;

namespace SubscriberManagementSystem.Web.Helper.Claims
{
    public interface IClaimsService
    {
        Task UpdateUserClaims(User user);
    }

}

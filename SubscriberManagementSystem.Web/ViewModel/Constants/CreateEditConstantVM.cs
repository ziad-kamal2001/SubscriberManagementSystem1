using SubscriberManagementSystem.Data.Models;

namespace SubscriberManagementSystem.Web.ViewModel.Constants
{
    public class CreateEditConstantVM
    {
        public Constant Constant { get; set; }
        public List<Constant> Parents { get; set; }
    }
}

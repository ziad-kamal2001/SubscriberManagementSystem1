using SubscriberManagementSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SubscriberManagementSystem.Web.ViewModel.Pages
{
    public class IndexPageVM
    {
        public List<SelectListItem> Parents { get; set; }
        public List<Module> Modules { get; set; }
    }
}

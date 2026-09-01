using SubscriberManagementSystem.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SubscriberManagementSystem.Web.ViewModel.Pages
{
    public class CreateEditPageVM
    {
        public Page? Page { get; set; }
        public List<SelectListItem>? Parents { get; set; }
        public List<PageCategory>? Categories { get; set; }
        public List<Module>? Modules { get; set; }
    }
}

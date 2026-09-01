using SubscriberManagementSystem.Data;
using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Data.Resources;
using SubscriberManagementSystem.Infrastructure.Services;
using SubscriberManagementSystem.Infrastructure.Services.UserPermissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SubscriberManagementSystem.Web.Controllers
{
    public class UserPermissionController : BaseController
    {
        private readonly IUserPermissionsService _userPermissionsService;

		public UserPermissionController(IUserPermissionsService userPermissionsService)
        {
            _userPermissionsService = userPermissionsService;
        }

        // display User Permission Page
        public async Task<IActionResult> Index()
        {
            var userPermissionsDto = await _userPermissionsService.GetUserPermissionsAsync();
			return View(userPermissionsDto);
        }

        // display User Type Permissions
        [HttpPost]
        public async Task<IActionResult> GetUserTypePermissions(int userTypeId)
        {
            var permissions = await _userPermissionsService.GetUserTypePermissionsAsync(userTypeId);
			return Json(permissions);
        }

        // Save User Type Permissions
        [HttpPost]
		public async Task<OperationResult> SavePermissions(int userTypeId, List<UserPermission> permissions)
        {
			return await _userPermissionsService.SavePermissionsAsync(userTypeId, permissions);
		}

    }
}

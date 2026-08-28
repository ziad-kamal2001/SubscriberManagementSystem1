using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Infrastructure.Services.UserPermissions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Infrastructure.Services.UserPermissions
{
	public interface IUserPermissionsService
	{
		Task<UserPermissionsDto> GetUserPermissionsAsync();
		Task<List<int>> GetUserTypePermissionsAsync(int userTypeId);
		Task<OperationResult> SavePermissionsAsync(int userTypeId, List<UserPermission> permissions);
        Task<bool> HasPermissionAsync(User user, string pageUrl);
		Task<bool> PageExistsAsync(string pageUrl);

    }
}

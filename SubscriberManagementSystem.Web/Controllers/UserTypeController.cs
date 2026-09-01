using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Infrastructure.Services;
using SubscriberManagementSystem.Infrastructure.Services.UserTypes;
using SubscriberManagementSystem.Data.Resources;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SubscriberManagementSystem.Web.Controllers
{
	public class UserTypeController : BaseController
    {
		private readonly IUserTypesService _userTypesService;

		public UserTypeController(IUserTypesService userTypesService)
		{
			_userTypesService = userTypesService;
		}

		[HttpPost] // display UserType DateTable
        public async Task<IActionResult> GetAll()
		{
			var inputSearch = Request.Form["search[value]"];
			var obj = !string.IsNullOrEmpty(inputSearch)
				? JsonConvert.DeserializeObject<UserType>(inputSearch) : new UserType();

			var result = await _userTypesService.GetAllAsync(new PagedResultRequestDto<UserType>
			{
				SearchValue = obj,
				SortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")],
				SortColumnDirection = Request.Form["order[0][dir]"],
				PageSize = int.Parse(Request.Form["length"]),
				Skip = int.Parse(Request.Form["start"])
			});

			return Ok(new { recordsFiltered = result.TotalCount, result.TotalCount, result.Data });
		}

        [HttpGet] // display UserType Page
        public IActionResult Index() => View();

        [HttpGet] // display create Edit User Type page
        public async Task<IActionResult> CreateEditModal(int id)
		{
			var userType = await _userTypesService.GetByIdOrDefaultAsync(id);
			return PartialView("_CreateEditModal", userType);
        }

        [HttpPost] // create Edit UserType 
        public async Task<OperationResult> CreateEdit(UserType input)
        {
            var result = new OperationResult(false, Messages.Invalid);
            if (!ModelState.IsValid)
            {
                var message = string.Join("<br>  ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                result.Message = message;
                return result;
            }
			
            return await _userTypesService.CreateEditAsync(input);
        }

        [HttpDelete]
        [HttpPost] // delete UserType 
        public async Task<OperationResult> Delete(int id)
		{
			return await _userTypesService.DeleteAsync(id);
		}
	}
}

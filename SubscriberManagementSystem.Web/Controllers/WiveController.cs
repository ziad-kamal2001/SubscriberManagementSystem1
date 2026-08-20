using SubscriberManagementSystem.Data.Enums;
using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Data.Resources;
using SubscriberManagementSystem.Infrastructure.Services;
using SubscriberManagementSystem.Infrastructure.Services.Wives;
using SubscriberManagementSystem.Infrastructure.Services.Constants;
using SubscriberManagementSystem.Web.ViewModel.Wives;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SubscriberManagementSystem.Web.Controllers
{
	public class WiveController : BaseController
	{
		private readonly IWivesService _wivesService;
        private readonly IConstantsService _constantsService;
        
        public WiveController(IWivesService wivesService, IConstantsService constantsService)
		{
            _wivesService = wivesService;
            _constantsService = constantsService;

        }

		[HttpPost] // Display Accounts DataTable
		public async Task<IActionResult> GetAll()
		{
			var inputSearch = Request.Form["search[value]"];
			var obj = !string.IsNullOrEmpty(inputSearch)
				? JsonConvert.DeserializeObject<Wive>(inputSearch) : new Wive();

			var result = await _wivesService.GetAllAsync(new PagedResultRequestDto<Wive>
			{
				SearchValue = obj,
				SortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")],
				SortColumnDirection = Request.Form["order[0][dir]"],
				PageSize = int.Parse(Request.Form["length"]),
				Skip = int.Parse(Request.Form["start"])
			});

			return Ok(new { recordsFiltered = result.TotalCount, result.TotalCount, result.Data });
		}

		[HttpGet] // Display Accounts Page
        public async Task<IActionResult> Index()
		{
			return View(new IndexWiveVM
            {
				//AccountTypes = await _wivesService.GetAccountTypesAsync(),
				//Currencies = await _wivesService.GetCurrencyListItemAsync()
			});
		}

		[HttpGet] // Display Create Edit Account Page
        public async Task<IActionResult> CreateEditModal(int id)
		{
			return PartialView("_CreateEditModal", new CreateEditWiveVM
            {
                Wive = await _wivesService.GetByIdOrDefaultAsync(id),

			});
		}

		[HttpPost] // Create Edit Wive
        public async Task<OperationResult> CreateEdit(Wive input)
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

			return await _wivesService.CreateEditAsync(input);
		}

		[HttpDelete] // Delete Account
        public async Task<OperationResult> Delete(int id)
		{
			return await _wivesService.DeleteAsync(id);
		}

        #region Account Type Actions

        [HttpGet] // Display Account Types page
        public IActionResult AccountsTypes() => View();

        [HttpPost] // Display Account Types DataTable
        //public async Task<IActionResult> GetAccountsTypes()
        //{
        //    var inputSearch = Request.Form["search[value]"];
        //    var obj = !string.IsNullOrEmpty(inputSearch)
        //        ? JsonConvert.DeserializeObject<Constant>(inputSearch) : new Constant();
        //    obj.ParentId = (int)GeneralEnums.AccountTypesId;

        //    var result = await _constantsService.GetAllAsync(new PagedResultRequestDto<Constant>
        //    {
        //        SearchValue = obj,
        //        SortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")],
        //        SortColumnDirection = Request.Form["order[0][dir]"],
        //        PageSize = int.Parse(Request.Form["length"]),
        //        Skip = int.Parse(Request.Form["start"])
        //    });

        //    return Ok(new { recordsFiltered = result.TotalCount, result.TotalCount, result.Data });
        //}

        //[HttpGet] // Display Create Edit Account Types page
        //public async Task<IActionResult> CreateEditAccountTypeModal(int id)
        //{
        //    var agencyType = await _constantsService.GetByParentIdOrDefaultAsync(id, (int)GeneralEnums.AccountTypesId);
        //    return PartialView("_CreateEditAccountTypeModal", agencyType);
        //}

        //[HttpPost] // Create Edit Account Types
        //public async Task<OperationResult> CreateEditAccountType(Constant input)
        //{
        //    var result = new OperationResult(false, Messages.Invalid);

        //    if (input.ParentId != (int)GeneralEnums.AccountTypesId)
        //    {
        //        ModelState.AddModelError("ParentError", Messages.InvalidAccountType);
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        var message = string.Join("<br>  ", ModelState.Values
        //            .SelectMany(v => v.Errors)
        //            .Select(e => e.ErrorMessage));
        //        result.Message = message;
        //        return result;
        //    }

        //    return await _constantsService.CreateEditAsync(input);
        //}

        [HttpDelete] // Delete Account Types
        public async Task<OperationResult> DeleteAccountType(int id)
        {
            return await _constantsService.DeleteAsync(id);
        }

        #endregion


    }
}



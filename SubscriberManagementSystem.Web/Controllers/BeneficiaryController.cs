using SubscriberManagementSystem.Data.Enums;
using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Data.Resources;
using SubscriberManagementSystem.Infrastructure.Services;
using SubscriberManagementSystem.Infrastructure.Services.Beneficiaries;
using SubscriberManagementSystem.Infrastructure.Services.BeneficiaryInformations;
using SubscriberManagementSystem.Infrastructure.Services.Constants;
using SubscriberManagementSystem.Web.ViewModel.Beneficiaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using SubscriberManagementSystem.Web.Helper.Files;

namespace SubscriberManagementSystem.Web.Controllers
{
    public class BeneficiaryController : BaseController
    {
        private readonly IBeneficiariesService _beneficiariesService;
        private readonly IBeneficiaryInformationsService _beneficiaryInformationsService;
        private readonly IConstantsService _constantsService;
        public const string tableBeneficiaries = "Beneficiaries";

        public BeneficiaryController(
            IBeneficiariesService beneficiariesService,
            IBeneficiaryInformationsService beneficiaryInformationsService,
            IConstantsService constantsService)


        {
            _beneficiariesService = beneficiariesService;
            _beneficiaryInformationsService = beneficiaryInformationsService;
            _constantsService = constantsService;

        }

        #region Beneficiary Actions

        [HttpPost] // Display Beneficiaries DataTable
        public async Task<IActionResult> GetAll()
        {
            var inputSearch = Request.Form["search[value]"];
            var obj = !string.IsNullOrEmpty(inputSearch)
                ? JsonConvert.DeserializeObject<Beneficiary>(inputSearch) : new Beneficiary();

            var result = await _beneficiariesService.GetAllAsync(new PagedResultRequestDto<Beneficiary>
            {
                SearchValue = obj,
                SortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")],
                SortColumnDirection = Request.Form["order[0][dir]"],
                PageSize = int.Parse(Request.Form["length"]),
                Skip = int.Parse(Request.Form["start"])
            });

            return Ok(new { recordsFiltered = result.TotalCount, result.TotalCount, result.Data });
        }

        [HttpGet] // Display Beneficiaries page
        public async Task<IActionResult> Index()
        {
            return View(new IndexBeneficiaryVM
            {
                //BeneficiaryTypes = await _beneficiariesService.GetBeneficiaryTypesAsync()

            });
        }

        [HttpGet] // Display Create Edit Beneficiaries Page
        public async Task<IActionResult> CreateEdit(int id, int? parentId)
        {
            var beneficiary = await _beneficiariesService.GetByIdOrDefaultAsync(id);
            if (parentId.HasValue && !beneficiary.ParentId.HasValue)
            {
                beneficiary.ParentId = parentId;
                beneficiary.Parent = await _beneficiariesService.GetByIdOrDefaultAsync((int)parentId);
            }

            return View(new CreateEditBeneficiaryVM
            {
                Beneficiary = beneficiary,
                //BeneficiaryTypes = await _beneficiariesService.GetBeneficiaryTypesAsync(),
                Genders = await _beneficiariesService.GetGendersAsync(),

            });
        }

        [HttpPost] // Create Edit Beneficiaries
        public async Task<OperationResult> SubmitCreateEdit(Beneficiary input)
        {
            var result = new OperationResult(false, Messages.Invalid);

            if (input.ParentId.HasValue)
            {
               
            }
            else
            {
                

                if (!input.BeneficiaryTypeId.HasValue)
                    ModelState.AddModelError("RequiredBeneficiaryType", Messages.RequiredBeneficiaryType);
            }

            if (!ModelState.IsValid)
            {
                var message = string.Join("<br>  ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                result.Message = message;
                return result;
            }

            return await _beneficiariesService.CreateEditAsync(input);
        }

        [HttpDelete] // Delete Beneficiary
        public async Task<OperationResult> Delete(int id)
        {
            return await _beneficiariesService.DeleteAsync(id);
        }

        #endregion


        #region Beneficiary Address Actions

        [HttpPost] // Display beneficiary Addresses DataTable
        public async Task<IActionResult> GetAddresses(int beneficiaryId)
        {
            var inputSearch = Request.Form["search[value]"];
            var obj = !string.IsNullOrEmpty(inputSearch)
                ? JsonConvert.DeserializeObject<BeneficiaryInformation>(inputSearch) : new BeneficiaryInformation();
            obj.BeneficiaryId = beneficiaryId;

            var result = await _beneficiaryInformationsService.GetAllAsync(new PagedResultRequestDto<BeneficiaryInformation>
            {
                SearchValue = obj,
                SortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")],
                SortColumnDirection = Request.Form["order[0][dir]"],
                PageSize = int.Parse(Request.Form["length"]),
                Skip = int.Parse(Request.Form["start"])
            });

            return Ok(new { recordsFiltered = result.TotalCount, result.TotalCount, result.Data });
        }

        [HttpGet] // Display Create Edit beneficiary Addresses Page
        public async Task<IActionResult> CreateEditAddressModal(int id)
        {
            return PartialView("_CreateEditAddressModal", new CreateEditAddressVM
            {
                BeneficiaryInformation = await _beneficiaryInformationsService.GetByIdOrDefaultAsync(id),
                //AddressTypes = await _beneficiaryInformationsService.GetAddressTypeAsync()
            });
        }

        [HttpPost] // Create Edit beneficiary Addresses
        public async Task<OperationResult> CreateEditAddress(BeneficiaryInformation input)
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

            return await _beneficiaryInformationsService.CreateEditAsync(input);
        }

        [HttpDelete] // Delete beneficiary Addresses
        public async Task<OperationResult> DeleteBeneficiary(int id)
        {
            return await _beneficiaryInformationsService.DeleteAsync(id);
        }





        #endregion







    }
}

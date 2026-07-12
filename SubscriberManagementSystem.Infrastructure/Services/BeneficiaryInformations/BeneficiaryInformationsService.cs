using SubscriberManagementSystem.Data.DbContext;
using SubscriberManagementSystem.Data.Enums;
using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Data.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace SubscriberManagementSystem.Infrastructure.Services.BeneficiaryInformations
{
	public class BeneficiaryInformationsService : BaseService, IBeneficiaryInformationsService
    {
		public BeneficiaryInformationsService(ApplicationDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
			: base(context, userManager, httpContextAccessor)
		{
		}

		public async Task<PagedResultDto<List<BeneficiaryInformation>>> GetAllAsync(PagedResultRequestDto<BeneficiaryInformation> input)
		{
			IQueryable<BeneficiaryInformation> beneficiaryInformations = _context.BeneficiaryInformations
				.Include(a => a.Beneficiary)
				.Where(a => a.BeneficiaryId == input.SearchValue.BeneficiaryId);

			if (!(string.IsNullOrEmpty(input.SortColumn) && string.IsNullOrEmpty(input.SortColumnDirection)))
                beneficiaryInformations = beneficiaryInformations.OrderBy(string.Concat(input.SortColumn, " ", input.SortColumnDirection));

			return new PagedResultDto<List<BeneficiaryInformation>>()
			{
				Data = await beneficiaryInformations.Skip(input.Skip).Take(input.PageSize).ToListAsync(),
				TotalCount = await beneficiaryInformations.CountAsync()
			};
		}

		//public async Task<List<Constant>> GetAddressTypeAsync()
		//{
		//	return await _context.Constants.Where(c => c.ParentId == (int)GeneralEnums.AddressType)
		//		.Select(c => new Constant { Id = c.Id, Name = c.Name }).ToListAsync();
		//}

		public async Task<BeneficiaryInformation> GetByIdOrDefaultAsync(int id)
		{
			var beneficiaryInformation = await _context.BeneficiaryInformations.SingleOrDefaultAsync(x => x.Id == id);
			if (beneficiaryInformation != null)
				return beneficiaryInformation;

			return new BeneficiaryInformation();
		}

		public async Task<OperationResult> CreateEditAsync(BeneficiaryInformation input)
		{
			var result = new OperationResult();
			try
			{
				if (input.IsDefaultAddress && await HasDefaultAddress(input.BeneficiaryId, input.Id))
				{
					result.Message = Messages.HasDefaultAddress;
				}
				else
				{
					var currentUserId = await GetCurrentUserIdAsync();

					if (input.Id == 0)
					{
						SetCreatedFields(input, currentUserId);
						await _context.BeneficiaryInformations.AddAsync(input);
					}
					else
					{
						SetUpdatedFields(input, currentUserId);

						_context.BeneficiaryInformations.Update(input);
						SetEntityModifiedFields(input);
					}

					await _context.SaveChangesAsync();

					result.Success = true;
					result.Message = Messages.Success;
				}

			}
			catch (Exception ex)
			{
				result.Message = Messages.Failed;
			}

			return result;
		}

		public async Task<OperationResult> DeleteAsync(int id)
		{
			var result = new OperationResult();

			var BeneficiaryInformation = await _context.BeneficiaryInformations.SingleOrDefaultAsync(x => x.Id == id);
			if (BeneficiaryInformation != null)
			{
				BeneficiaryInformation.IsDeleted = true;
				BeneficiaryInformation.DeletedBy = await GetCurrentUserIdAsync();

				_context.BeneficiaryInformations.Update(BeneficiaryInformation);
				await _context.SaveChangesAsync();

				result.Success = true;
				result.Message = Messages.Success;
			}
			return result;
		}

		private async Task<bool> HasDefaultAddress(int beneficiaryId, int addressId)
		{
			var defaultAddress = await _context.BeneficiaryInformations
                .SingleOrDefaultAsync(ba => ba.BeneficiaryId == beneficiaryId
				&& ba.IsDefaultAddress
				&& ba.Id != addressId);

			if (defaultAddress != null)
				return true;

			return false;
		}
	}
}

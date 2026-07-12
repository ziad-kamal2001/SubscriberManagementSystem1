using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Data.Resources;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using SubscriberManagementSystem.Data.DbContext;
using SubscriberManagementSystem.Data.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace SubscriberManagementSystem.Infrastructure.Services.Childrens
{
    public class ChildrensService : BaseService, IChildrensService
    {
		public ChildrensService(ApplicationDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
			: base(context, userManager, httpContextAccessor)
		{
		}

		public async Task<PagedResultDto<List<Children>>> GetAllAsync(PagedResultRequestDto<Children> input)
		{
			IQueryable<Children> childrens = _context.Childrens
                .Include(a => a.Beneficiary)
                .Where(x => string.IsNullOrEmpty(input.SearchValue.Keyword)
				? true : (x.Name.Contains(input.SearchValue.Keyword)
						|| x.IDNumber.Contains(input.SearchValue.IDNumber)));
			if (input.SearchValue.BeneficiaryId > 0)
                childrens = childrens.Where(x => x.BeneficiaryId == input.SearchValue.BeneficiaryId);

			if (!(string.IsNullOrEmpty(input.SortColumn) && string.IsNullOrEmpty(input.SortColumnDirection)))
                childrens = childrens.OrderBy(string.Concat(input.SortColumn, " ", input.SortColumnDirection));

			return new PagedResultDto<List<Children>>()
			{
				Data = await childrens.Skip(input.Skip).Take(input.PageSize).ToListAsync(),
				TotalCount = await childrens.CountAsync()
			};
		}


		public async Task<Children> GetByIdOrDefaultAsync(int id)
		{
			var childrens =  await _context.Childrens.SingleOrDefaultAsync(x => x.Id == id);
			if(childrens != null)
				return childrens;

			return new Children();
		}

		public async Task<OperationResult> CreateEditAsync(Children input)
		{
			var result = new OperationResult();
			try
			{
				var currentUserId = await GetCurrentUserIdAsync();

				if (input.Id == 0)
				{
					SetCreatedFields(input, currentUserId);
					await _context.Childrens.AddAsync(input);
				}
				else
				{
					SetUpdatedFields(input, currentUserId);
					_context.Childrens.Update(input);
                    SetEntityModifiedFields(input);
                }

				await _context.SaveChangesAsync();

				result.Success = true;
				result.Message = Messages.Success;
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
			var account = await _context.Wives.SingleOrDefaultAsync(x => x.Id == id);
			if (account != null)
			{
				account.IsDeleted = true;
				account.DeletedBy = await GetCurrentUserIdAsync();

				_context.Wives.Update(account);
				await _context.SaveChangesAsync();

				result.Success = true;
				result.Message = Messages.Success;
			}
			return result;
		}
	}
}

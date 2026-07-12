using SubscriberManagementSystem.Data.DbContext;
using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Data.Resources;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriberManagementSystem.Data.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace SubscriberManagementSystem.Infrastructure.Services.Beneficiaries
{
    public class BeneficiariesService : BaseService, IBeneficiariesService
    {
        public BeneficiariesService(ApplicationDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
            : base(context, userManager, httpContextAccessor)
        {
        }

        public async Task<PagedResultDto<List<Beneficiary>>> GetAllAsync(PagedResultRequestDto<Beneficiary> input)
        {
            IQueryable<Beneficiary> beneficiaries = _context.Beneficiaries
                .Include(b => b.BeneficiaryType)
                .Select(b => new Beneficiary
                {
                    Id = b.Id,
                    FName = b.FName,
                    SName = b.SName,
                    TName = b.TName,
                    LName = b.LName,
                    DOB = b.DOB,
                    IsActive = b.IsActive,
                    IDNumber=b.IDNumber,
                    PhoneNumber=b.PhoneNumber,
                    ParentId = b.ParentId,
                    CampName = _context.BeneficiaryInformations
                        .Where(ba => ba.BeneficiaryId == b.Id && ba.IsDefaultAddress)
                        .Select(ba => ba.Camp)
                        .FirstOrDefault(),


                })
                .Where(b => b.ParentId == input.SearchValue.ParentId)
                .Where(x => string.IsNullOrEmpty(input.SearchValue.Keyword)
                ? true : (
                        x.FName.Contains(input.SearchValue.Keyword)
                        || x.SName.Contains(input.SearchValue.Keyword)
                        || x.TName.Contains(input.SearchValue.Keyword)
                        || x.LName.Contains(input.SearchValue.Keyword)
                        || x.CampName.Contains(input.SearchValue.Keyword)
                        || x.IDNumber.Contains(input.SearchValue.Keyword)
                        ));

            if (input.SearchValue.IsActiveSearch != null)
                beneficiaries = beneficiaries.Where(x => x.IsActive == input.SearchValue.IsActiveSearch);

            if (input.SearchValue.BeneficiaryTypeId > 0)
                beneficiaries = beneficiaries.Where(x => x.BeneficiaryTypeId == input.SearchValue.BeneficiaryTypeId);

            if (input.SortColumn != "")
            {
                beneficiaries = beneficiaries.OrderBy(string.Concat(input.SortColumn, " ", input.SortColumnDirection));
            }
            else
            {
                beneficiaries = beneficiaries
                   .OrderBy(x => x.FName)
                   .OrderBy(x => x.SName)
                   .OrderBy(x => x.TName)
                   .OrderBy(x => x.LName);
            }

            return new PagedResultDto<List<Beneficiary>>()
            {
                Data = await beneficiaries.Skip(input.Skip).Take(input.PageSize).ToListAsync(),
                TotalCount = await beneficiaries.CountAsync()
            };
        }

        public async Task<Beneficiary> GetByIdOrDefaultAsync(int id)
        {
            var beneficiary = await _context.Beneficiaries.Include(x => x.Parent).SingleOrDefaultAsync(x => x.Id == id);
            if (beneficiary != null)
                return beneficiary;

            return new Beneficiary();
        }

        public async Task<OperationResult> CreateEditAsync(Beneficiary input)
        {
            var result = new OperationResult();
            try
            {
                var currentUserId = await GetCurrentUserIdAsync();

                if (input.Id == 0)
                {
                    SetCreatedFields(input, currentUserId);
                    var addedBeneficiary = await _context.Beneficiaries.AddAsync(input);
                    await _context.SaveChangesAsync();
                    result.ReturnId = addedBeneficiary.Entity.Id;
                }
                else
                {
                    SetUpdatedFields(input, currentUserId);
                    var updatedBeneficiary = _context.Beneficiaries.Update(input);
                    SetEntityModifiedFields(input);

                    await _context.SaveChangesAsync();
                    result.ReturnId = updatedBeneficiary.Entity.Id;

                }

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
            var beneficiary = await _context.Beneficiaries.SingleOrDefaultAsync(x => x.Id == id);
            if (beneficiary != null)
            {
                beneficiary.IsDeleted = true;
                beneficiary.DeletedBy = await GetCurrentUserIdAsync();

                _context.Beneficiaries.Update(beneficiary);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = Messages.Success;
            }
            return result;
        }

        public async Task<List<Constant>> GetGendersAsync()
        {
            return await _context.Constants.Where(c => c.ParentId == (int)GeneralEnums.Gender)
                .Select(c => new Constant { Id = c.Id, Name = c.Name }).ToListAsync();
        }

        //public async Task<List<Constant>> GetCategoriesAsync()
        //{
        //    return await _context.Constants.Where(c => c.ParentId == (int)GeneralEnums.BeneficiaryCategory)
        //        .Select(c => new Constant { Id = c.Id, Name = c.Name }).ToListAsync();
        //}



    }
}

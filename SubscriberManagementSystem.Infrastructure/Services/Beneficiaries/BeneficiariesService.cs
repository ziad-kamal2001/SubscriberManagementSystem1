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
                    IDNumber = b.IDNumber,
                    PhoneNumber = b.PhoneNumber,
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
            var beneficiary = await _context.Beneficiaries
                .Include(x => x.Parent)
                .Include(x => x.Gender)
                .Include(x => x.BeneficiaryType)
                .Include(x => x.MaritalStatus)
                .Include(x => x.BreadwinnerStatus)
                .Include(x => x.WifeStatus)
                .Include(x => x.OriginalGovernorateCity)
                .SingleOrDefaultAsync(x => x.Id == id);

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

        public async Task<List<Constant>> GetBeneficiaryTypesAsync()
        {
            return await _context.Constants.Where(c => c.ParentId == (int)GeneralEnums.BeneficiaryType)
                .Select(c => new Constant { Id = c.Id, Name = c.Name }).ToListAsync();
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

        // ---- New lookups for the extended CreateEdit form ----

        public async Task<List<Constant>> GetMaritalStatusesAsync()
        {
            return await _context.Constants.Where(c => c.ParentId == (int)GeneralEnums.MaritalStatus)
                .Select(c => new Constant { Id = c.Id, Name = c.Name }).ToListAsync();
        }

        public async Task<List<Constant>> GetBreadwinnerStatusesAsync()
        {
            return await _context.Constants.Where(c => c.ParentId == (int)GeneralEnums.BreadwinnerStatus)
                .Select(c => new Constant { Id = c.Id, Name = c.Name }).ToListAsync();
        }

        public async Task<List<Constant>> GetWifeStatusesAsync()
        {
            return await _context.Constants.Where(c => c.ParentId == (int)GeneralEnums.WifeStatus)
                .Select(c => new Constant { Id = c.Id, Name = c.Name }).ToListAsync();
        }

        public async Task<List<Constant>> GetResidenceStatusesAsync()
        {
            return await _context.Constants.Where(c => c.ParentId == (int)GeneralEnums.ResidenceStatus)
                .Select(c => new Constant { Id = c.Id, Name = c.Name }).ToListAsync();
        }

        public async Task<List<City>> GetCitiesListAsync()
        {
            return await _context.Cities
                .Select(c => new City { Id = c.Id, Name = c.Name }).ToListAsync();
        }

        // ---- Computed family member counters ----
        // NOTE: Disabled/Martyrs/Injured counters require new boolean flags
        // (e.g. IsDisabled, IsMartyr, IsInjured) to be added to Beneficiary/Wive/Children.
        // Those columns don't exist yet, so those three counters return 0 for now.
        public async Task<FamilyMembersCountDto> GetFamilyMembersCountAsync(int beneficiaryId)
        {
            var result = new FamilyMembersCountDto();
            var today = DateTime.Today;

            // Relatives (children/other dependents modeled as Beneficiary rows with ParentId)
            var relatives = await _context.Beneficiaries
                .Where(b => b.ParentId == beneficiaryId)
                .Select(b => new { b.DOB, b.GenderId })
                .ToListAsync();

            // Wives
            var wives = await _context.Wives
                .Where(w => w.BeneficiaryId == beneficiaryId)
                .Select(w => new { w.DOB })
                .ToListAsync();

            // Children
            var children = await _context.Childrens
                .Where(c => c.BeneficiaryId == beneficiaryId)
                .Select(c => new { c.DOB, c.GenderId, c.TheHealthConditionId })
                .ToListAsync();

            void Accumulate(DateTime? dob, bool isFemale)
            {
                if (!dob.HasValue) return;
                var age = today.Year - dob.Value.Year;
                if (dob.Value.Date > today.AddYears(-age)) age--;

                if (isFemale)
                {
                    if (age <= 2) result.Female0To2++;
                    else if (age <= 5) result.Female3To5++;
                    else if (age <= 18) result.Female6To18++;
                    else if (age <= 59) result.Female19To59++;
                    else result.Female60Plus++;
                }
                else
                {
                    if (age <= 2) result.Male0To2++;
                    else if (age <= 5) result.Male3To5++;
                    else if (age <= 18) result.Male6To18++;
                    else if (age <= 59) result.Male19To59++;
                    else result.Male60Plus++;
                }
            }

            foreach (var r in relatives)
                Accumulate(r.DOB, r.GenderId == (int)GeneralEnums.Female);

            foreach (var w in wives)
                Accumulate(w.DOB, true);

            foreach (var c in children)
            {
                Accumulate(c.DOB, c.GenderId == (int)GeneralEnums.Female);
                if (c.TheHealthConditionId == (int)GeneralEnums.Negative)
                    result.ChronicIllnessCount++;
            }

            return result;
        }
    }
}

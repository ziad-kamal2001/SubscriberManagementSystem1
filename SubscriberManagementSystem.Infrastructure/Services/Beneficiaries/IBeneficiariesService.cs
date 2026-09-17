using SubscriberManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Infrastructure.Services.Beneficiaries
{
    public interface IBeneficiariesService
    {
        Task<PagedResultDto<List<Beneficiary>>> GetAllAsync(PagedResultRequestDto<Beneficiary> input);
        Task<Beneficiary> GetByIdOrDefaultAsync(int id);
        Task<OperationResult> CreateEditAsync(Beneficiary input);
        Task<OperationResult> DeleteAsync(int id);
        Task<List<Constant>> GetGendersAsync();
        Task<List<Constant>> GetBeneficiaryTypesAsync();

        // New lookups for the extended CreateEdit form
        Task<List<Constant>> GetMaritalStatusesAsync();
        Task<List<Constant>> GetBreadwinnerStatusesAsync();
        Task<List<Constant>> GetWifeStatusesAsync();
        Task<List<Constant>> GetResidenceStatusesAsync();
        Task<List<City>> GetCitiesListAsync();
        Task<List<TheHealthCondition>> GetHealthConditionsAsync();

        // Family member counters, computed from Beneficiary/Wive/Children relations
        Task<FamilyMembersCountDto> GetFamilyMembersCountAsync(int beneficiaryId);
    }
}

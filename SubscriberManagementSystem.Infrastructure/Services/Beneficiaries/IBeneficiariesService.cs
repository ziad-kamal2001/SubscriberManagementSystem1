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

    }
}

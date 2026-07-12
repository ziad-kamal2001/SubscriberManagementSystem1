using SubscriberManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Infrastructure.Services.BeneficiaryInformations
{
	public interface IBeneficiaryInformationsService
	{
		Task<PagedResultDto<List<BeneficiaryInformation>>> GetAllAsync(PagedResultRequestDto<BeneficiaryInformation> input);
		//Task<List<Constant>> GetAddressTypeAsync();
		Task<BeneficiaryInformation> GetByIdOrDefaultAsync(int id);
		Task<OperationResult> CreateEditAsync(BeneficiaryInformation input);
		Task<OperationResult> DeleteAsync(int id);
	}
}

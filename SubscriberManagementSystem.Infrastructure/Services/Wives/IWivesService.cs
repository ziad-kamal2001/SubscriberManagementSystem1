using SubscriberManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Infrastructure.Services.Wives
{
	public interface IWivesService
    {
		Task<PagedResultDto<List<Wive>>> GetAllAsync(PagedResultRequestDto<Wive> input);
		Task<Wive> GetByIdOrDefaultAsync(int id);
		Task<OperationResult> CreateEditAsync(Wive input);
		Task<OperationResult> DeleteAsync(int id);
		
    }
}

using SubscriberManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Infrastructure.Services.Childrens
{
	public interface IChildrensService
    {
		Task<PagedResultDto<List<Children>>> GetAllAsync(PagedResultRequestDto<Children> input);
		Task<Children> GetByIdOrDefaultAsync(int id);
		Task<OperationResult> CreateEditAsync(Children input);
		Task<OperationResult> DeleteAsync(int id);
		
    }
}

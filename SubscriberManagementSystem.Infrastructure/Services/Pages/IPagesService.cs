using SubscriberManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Infrastructure.Services.Pages
{
    public interface IPagesService
    {
        Task<PagedResultDto<List<Page>>> GetAllAsync(PagedResultRequestDto<Page> input);
        Task<Page> GetByIdOrDefaultAsync(int id);
        Task<OperationResult> CreateEditAsync(Page input);
        Task<OperationResult> DeleteAsync(int id);
        Task<List<Page>> GetParentsListAsync();
        Task<List<Module>> GetModulesListAsync();
        Task<List<PageCategory>> GetCategoriesListAsync();
        Task<List<Page>> GetPagesListForMenu();
    }
}

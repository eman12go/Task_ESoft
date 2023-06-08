using Elmeya_Soft.IService;
using Elmeya_Soft.Models;
using EntityFrameWorkDemo;
using Microsoft.EntityFrameworkCore;

namespace Elmeya_Soft.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationContext _applicationContext;

        public CategoryService(ApplicationContext applicationContext)
        {
            
            _applicationContext = applicationContext;
        }
        public async Task<List<Category>> GetAllCategories(int typeId)
        {
            return await _applicationContext
                .Categories
                .Where(t => t.TypeId == typeId)
                .ToListAsync();
        }

        public int? GetPrice(int id)
        {
            return _applicationContext
                .Categories
                .FirstOrDefault(c => c.Id == id)?.Cost;
        }
    }
}

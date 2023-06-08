using Elmeya_Soft.Models;

namespace Elmeya_Soft.IService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories(int typeId);
        int? GetPrice(int id);
    }
}

using Elmeya_Soft.IService;
using EntityFrameWorkDemo;
using Microsoft.EntityFrameworkCore;
using Type = Elmeya_Soft.Models.Type;

namespace Elmeya_Soft.Services
{
    public class TypeService : ITypeService
    {
        private readonly ApplicationContext _applicationContext;

        public TypeService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<List<Type>> GetAllTypes()
        {
            return await _applicationContext
                .Types
                .ToListAsync();
        }
    }
}

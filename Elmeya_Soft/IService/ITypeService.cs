using Type = Elmeya_Soft.Models.Type;
namespace Elmeya_Soft.IService
{
    public interface ITypeService
    {
        Task<List<Type>> GetAllTypes();
    }
}

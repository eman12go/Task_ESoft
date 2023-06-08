using Elmeya_Soft.Models;

namespace Elmeya_Soft.IService
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClients();
    }
}

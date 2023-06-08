using Elmeya_Soft.IService;
using Elmeya_Soft.Models;
using EntityFrameWorkDemo;
using Microsoft.EntityFrameworkCore;

namespace Elmeya_Soft.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationContext _applicationContext;

        public ClientService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<List<Client>> GetAllClients()
        {
            List<Client> clients = await _applicationContext
                .Clients
                .ToListAsync();
            return clients;
        }
    }
}

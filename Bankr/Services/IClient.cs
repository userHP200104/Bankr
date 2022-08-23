using System;
namespace Bankr.Services
{
	public interface IClient
    {

        Task<List<Client>> GetClientList();
        Task<int> AddClient(Client client);
        Task<int> DeleteClient(Client client);
        Task<int> UpdateClient(Client client);

    }
}


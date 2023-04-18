using ClientsBlazor.Shared;

namespace ClientsBlazor.Server.Services.ClientService
{
    public interface IClientService
    {
        Task<List<Klient>> GetAllClients();
        Task<Klient?> GetSingleClient(int id);
        Task<Klient> AddClient(Klient client);
        Task<Klient?> UpdateClient(int id, Klient ćlient);
        Task<bool> DeleteClient(int id);

    }
}

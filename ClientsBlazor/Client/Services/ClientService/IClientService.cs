using ClientsBlazor.Shared;

namespace ClientsBlazor.Client.Services.ClientService
{
    public interface IClientService
    {
        List<Klient> Clients { get; set; }

        Task GetAllClients();
        Task<Klient?> GetSingleClient(int id);
        Task AddClient(Klient client);
        Task UpdateClient(int id, Klient ćlient);
        Task DeleteClient(int id);

    }
}

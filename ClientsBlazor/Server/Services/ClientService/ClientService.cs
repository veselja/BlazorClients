using Microsoft.EntityFrameworkCore;
using ClientsBlazor.Server.Data;
using ClientsBlazor.Shared;

namespace ClientsBlazor.Server.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly DataContext _context;

        public ClientService(DataContext context)
        {
            _context = context;
        }


        public async Task<Klient> AddClient(Klient client)
        {

            _context.Add(client);
            await _context.SaveChangesAsync(); //uloží změny
            return client; //vypíše updatované hodnoty
        }

        public async Task<bool> DeleteClient(int id)
        {
            var dbClient = await _context.Clients.FindAsync(id);
            if (dbClient == null)
            {
                return false;
            }

            _context.Remove(dbClient);
            await _context.SaveChangesAsync(); //uloží změny do db

            return true;
        }

        public async Task<List<Klient>> GetAllClients()
        {
           return await _context.Clients.ToListAsync();
           
        }

        public async Task<Klient?> UpdateClient(int id, Klient client)
        {
            var dbClient = await _context.Clients.FindAsync(id);
            if (dbClient != null)
            {
                dbClient.SongName = client.SongName;
                dbClient.Instagram = client.Instagram;
                dbClient.Orders = client.Orders;

                await _context.SaveChangesAsync();
            }
            return dbClient;
        }
        public async Task<Klient?> GetSingleClient(int id)
        {
            var dbClient = await _context.Clients.FindAsync(id); //najde studenta, kde se jeho ID (pripární klíč) rovná ID této metody //FindAsync = najde entity se zadaných pripírním klíčem
            
            return dbClient;
        }
    }
}

using ClientsBlazor.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ClientsBlazor.Client.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ClientService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Klient> Clients { get; set; } = new List<Klient>(); //bez new CS8618

        public async Task AddClient(Klient client)
        {
            await _http.PostAsJsonAsync("api/client", client);
            _navigationManager.NavigateTo("clients"); //zpět na main
        }

        public async Task DeleteClient(int id)
        {
            var result = await _http.DeleteAsync($"api/client/{id}");
            _navigationManager.NavigateTo("clients");
        }

        public async Task GetAllClients()
        {
            var result = await _http.GetFromJsonAsync<List<Klient>>("api/client"); //route z server ClientController
            if (result is not null)
                Clients = result;
        }


        public async Task<Klient?> GetSingleClient(int id)
        {
            var result = await _http.GetAsync($"api/client/{id}");
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Klient?>();
            }
            return null;
        }

        public async Task UpdateClient(int id, Klient client)
        {
            await _http.PutAsJsonAsync($"api/client/{id}", client);
            _navigationManager.NavigateTo("clients");

        }
    }
}

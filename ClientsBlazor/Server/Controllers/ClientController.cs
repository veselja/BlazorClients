using ClientsBlazor.Server.Services;
using ClientsBlazor.Server.Services.ClientService;

using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using ClientsBlazor.Shared;
using ClientsBlazor.Client.Pages;
using Microsoft.AspNetCore.Http;



namespace ClientsBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _ClientService;

        public ClientController(IClientService ClientService)
        {
            _ClientService = ClientService; //repository injection
        }


        [HttpGet] //povinnost použít tento artibut pro swagger api
        public async Task<List<Klient>> GetAllClients() //někdy stačí restartovat applikaci pro vyřešení nějakého erroru.
        {
            //vrátí seznam studentů
            //Models.Student = directory 
            return await _ClientService.GetAllClients();
        }


        [HttpGet("{id}")] //"propojení" s id (primarní klíč) z student.cs (konstruktor)
        [Route("{id}")]
        /*
        taky se dá napsat jako: 
        [HttpGet]
        [Route("{id}")]
         */
        public async Task<Klient?> GetSingleClient(int id)
        {
            return await _ClientService.GetSingleClient(id);
            //if (result is null)
            //    return NotFound("Student not found.");

            
        }

        [HttpPost]
        public async Task<Klient?> AddClient(Klient client)
        {
            return await _ClientService.AddClient(client);
            //if (result is null)
            //    return NotFound("Student not found.");

            
        }

        [HttpPut("{id}")]
        public async Task<Klient?> UpdateClient(Klient client, int id)
        {
            return await _ClientService.UpdateClient(id, client);

        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteClient(int id)
        {
            return await _ClientService.DeleteClient(id);
            
        }


    }
}

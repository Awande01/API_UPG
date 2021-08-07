using BL.ApiResponse;
using BL.Interface;
using BL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository iclientrepository;
        public ClientController(IClientRepository _iclientrepository)
        {
            iclientrepository = _iclientrepository;
        }
        // GET: api/<ClientController>
        [HttpGet("/GetAll")]
        public async Task<IEnumerable<object>> GetAll()
        {
          return   await iclientrepository.GetAllAsyc();
             
        }

        // POST api/<ClientController>
        [HttpPost("/Add")]
        public async Task<Response> Add(Client model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await iclientrepository.InsertAsyc(model);
            return apiResp;
        }

        // PUT api/<ClientController>/5
        [HttpPut("/Update")]
        public async Task<Response> Update(Client model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await iclientrepository.UpdateAsyc(model);
            return apiResp;
        }
        // Delete api/<ClientController>/5
        [HttpDelete("/Delete")]
        public async Task<Response> Delete(int  clientID)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await iclientrepository.DeleteAsyc(clientID);
            return apiResp;
        }
        // GET: api/<ClientController>
        [HttpGet("/GetByID")]
        public async Task<object> GetByID(int clientID)
        {
            return await iclientrepository.GetByIDAysc(clientID);
        }

        // GET: api/<ClientController>
        [HttpGet("/GetGender")]
        public async Task<IEnumerable<object>> GetGender()
        {
            return await iclientrepository.GetGender();

        }
    }
}

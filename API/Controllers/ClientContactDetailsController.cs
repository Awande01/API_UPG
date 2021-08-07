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
    public class ClientContactDetailsController : ControllerBase
    {
        private readonly IClientContactDetailsRepository iclientcontactdetailsrepository;
        public ClientContactDetailsController(IClientContactDetailsRepository _iclientcontactdetailsrepository)
        {
            iclientcontactdetailsrepository = _iclientcontactdetailsrepository;
        }

        // POST api/<ClientContactDetailsController>
        [HttpPost("/AddContact")]
        public async Task<Response> AddContact(ClientDetails model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await iclientcontactdetailsrepository.InsertAsyc(model);
            return apiResp;
        }

        // PUT api/<ClientContactDetailsController>/5
        [HttpPut("/UpdateContact")]
        public async Task<Response> UpdateContact(ClientDetails model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await iclientcontactdetailsrepository.UpdateAsyc(model);
            return apiResp;
        }
        // GET: api/<ClientContactDetailsController>
        [HttpGet("/GetContactByID")]
        public async Task<IEnumerable<object>> GetContactByID(int clientID)
        {
            var data = await iclientcontactdetailsrepository.GetByIDAysc(clientID);
            return data;
        }
        // GET: api/<ClientContactDetailsController>
        [HttpGet("/GetContactTypes")]
        public async Task<IActionResult> GetContactTypes()
        {
            var data = await iclientcontactdetailsrepository.GetContactTypes();
            return Ok(data);
        }
        // Delete api/<ClientContactDetailsController>/5
        [HttpDelete("/DeleteContact")]
        public async Task<Response> DeleteContact(int clientContactID)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await iclientcontactdetailsrepository.DeleteAsyc(clientContactID);
            return apiResp;
        }
    }
}

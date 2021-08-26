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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository icustomerrepository;
        public CustomerController(ICustomerRepository _icustomerrepository)
        {
            icustomerrepository = _icustomerrepository;
        }
        // GET: api/<ClientController>
        [HttpGet("/GetAll")]
        public async Task<IEnumerable<object>> GetAll()
        {
          return   await icustomerrepository.GetAllAsyc();
             
        }

        // POST api/<ClientController>
        [HttpPost("/Add")]
        public async Task<Response> Add(Customer model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await icustomerrepository.InsertAsyc(model);
            return apiResp;
        }

        // PUT api/<ClientController>/5
        [HttpPut("/Update")]
        public async Task<Response> Update(Customer model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await icustomerrepository.UpdateAsyc(model);
            return apiResp;
        }
        // Delete api/<ClientController>/5
        [HttpDelete("/Delete")]
        public async Task<Response> Delete(int customerID)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await icustomerrepository.DeleteAsyc(customerID);
            return apiResp;
        }
        // GET: api/<ClientController>
        [HttpGet("/GetByID")]
        public async Task<object> GetByID(int customerID)
        {
            return await icustomerrepository.GetByIDAysc(customerID);
        }

        // GET: api/<ClientController>
        [HttpGet("/GetTypes")]
        public async Task<IEnumerable<object>> GetTypes()
        {
            return await icustomerrepository.GetTypes();

        }
    }
}

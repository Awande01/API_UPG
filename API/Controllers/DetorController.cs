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
    public class DetorController : ControllerBase
    {
        private readonly IDetorsMasterRepository idetorspository;
        private readonly IDetorsTransactionRepository itransactionrepository;
        public DetorController(IDetorsMasterRepository _idetorsrepository, IDetorsTransactionRepository _itransactionrepository)
        {
            idetorspository = _idetorsrepository;
            itransactionrepository = _itransactionrepository;
        }
        // GET: api/<ClientController>
        [HttpGet("/GetAllDetors")]
        public async Task<IEnumerable<object>> GetAllDetors()
        {
          return   await idetorspository.GetAllAsyc();
             
        }

        // POST api/<ClientController>
        [HttpPost("/AddDetor")]
        public async Task<Response> AddDetor(DetorsMaster model)
        {
            var apiResp = new Response { ResponseType = -1 };
            apiResp.ResponseCode = await idetorspository.InsertAsyc(model);
            return apiResp;
        }

        // PUT api/<ClientController>/5
        [HttpPut("/UpdateDetor")]
        public async Task<Response> UpdateDetor(DetorsMaster model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await idetorspository.UpdateAsyc(model);
            return apiResp;
        }
        // GET: api/<ClientController>
        [HttpGet("/GetDetorByID")]
        public async Task<object> GetDetorByID(int clientID)
        {
            return await idetorspository.GetByIDAysc(clientID);
        }
        // POST api/<ClientController>
        [HttpPost("/AddDetorTransaction")]
        public async Task<Response> AddDetorTransaction(DetorsMaster model)
        {
            var apiResp = new Response { ResponseType = -1 };
            apiResp.ResponseCode = await idetorspository.InsertAsyc(model);
            return apiResp;
        }

        // PUT api/<ClientController>/5
        [HttpPut("/UpdateDetorTransaction")]
        public async Task<Response> UpdateDetorTransaction(DetorsMaster model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await idetorspository.UpdateAsyc(model);
            return apiResp;
        }
        // GET: api/<ClientController>
        [HttpGet("/GetDetorTransactionByID")]
        public async Task<object> GetDetorTransactionByID(int clientID)
        {
            return await idetorspository.GetByIDAysc(clientID);
        }
    }
}

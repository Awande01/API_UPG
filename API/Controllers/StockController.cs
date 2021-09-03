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
    public class StockController : ControllerBase
    {
        private readonly IStockMasterRepository istockpository;
        private readonly IStockTransactionRepository itransactionrepository;
        public StockController(IStockMasterRepository _istockrepository, IStockTransactionRepository _itransactionrepository)
        {
            istockpository = _istockrepository;
            itransactionrepository = _itransactionrepository;
        }
        // GET: api/<ClientController>
        [HttpGet("/GetAllStock")]
        public async Task<IEnumerable<object>> GetAllStock()
        {
            return await istockpository.GetAllAsyc();

        }

        // POST api/<ClientController>
        [HttpPost("/AddStock")]
        public async Task<Response> AddStock(StockMaster model)
        {
            var apiResp = new Response { ResponseType = -1 };
            apiResp.ResponseCode = await istockpository.InsertAsyc(model);
            return apiResp;
        }

        // PUT api/<ClientController>/5
        [HttpPut("/UpdateStock")]
        public async Task<Response> UpdateStock(StockMaster model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await istockpository.UpdateAsyc(model);
            return apiResp;
        }
        //// GET: api/<ClientController>
        //[HttpGet("/GetDetorByID")]
        //public async Task<object> GetDetorByID(int clientID)
        //{
        //    return await istockpository.GetByIDAysc(clientID);
        //}
        // POST api/<ClientController>
        [HttpPost("/AddStockTransaction")]
        public async Task<Response> AddStockTransaction(StockTransaction model)
        {
            var apiResp = new Response { ResponseType = -1 };
            apiResp.ResponseType = await itransactionrepository.InsertAsyc(model);
            return apiResp;
        }

        // PUT api/<ClientController>/5
        [HttpPut("/UpdateStockTransaction")]
        public async Task<Response> UpdateStockTransaction(StockTransaction model)
        {
            var apiResp = new Response { ResponseType = 0 };
            apiResp.ResponseType = await itransactionrepository.UpdateAsyc(model);
            return apiResp;
        }
        //// GET: api/<ClientController>
        //[HttpGet("/GetStockTransactionByID")]
        //public async Task<object> GetStockTransactionByID(int clientID)
        //{
        //    return await itransactionrepository.GetByIDAysc(clientID);
        //}
    }
}

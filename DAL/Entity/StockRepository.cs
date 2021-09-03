using BL.Interface;
using BL.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class StockRepository : IStockMasterRepository
    {
        private readonly IConfiguration configuration;
        public StockRepository(IConfiguration _configuration)
        {
             configuration = _configuration;
        }

        public async Task<string> InsertAsyc(StockMaster model)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string result;
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@StockCode", dbType: System.Data.DbType.String,direction:System.Data.ParameterDirection.Output,size: 5215585);
                parameter.Add("@StockDescription", model.StockDescription);
                parameter.Add("@QtyPurchased", model.QtyPurchased);
                parameter.Add("@Cost", model.Cost);
                parameter.Add("@QtySold", model.QtySold);
                parameter.Add("@SellingPrice", model.SellingPrice);
                parameter.Add("@StockOnHand", model.StockOnHand);
                parameter.Add("@TotalPurchasesExclVat", model.TotalPurchasesExclVat);
                parameter.Add("@TotalSalesExclVat", model.TotalSalesExclVat);
                await SqlMapper.ExecuteAsync(connection, "[dbo].[InsertStockMaster]", parameter, commandType: System.Data.CommandType.StoredProcedure);
                result = parameter.Get<string>("@StockCode");
                connection.Close();
                return result;
            }
        }
        public async Task<int> UpdateAsyc(StockMaster model)
        {
            using(var connection =new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@StockMasterID", model.StockMasterID);
                parameter.Add("@StockCode", model.StockCode);
                parameter.Add("@StockDescription", model.StockDescription);
                parameter.Add("@QtyPurchased", model.QtyPurchased);
                parameter.Add("@Cost", model.Cost);
                parameter.Add("@QtySold", model.QtySold);
                parameter.Add("@SellingPrice", model.SellingPrice);
                parameter.Add("@StockOnHand", model.StockOnHand);
                parameter.Add("@TotalPurchasesExclVat", model.TotalPurchasesExclVat);
                parameter.Add("@TotalSalesExclVat", model.TotalSalesExclVat);
                var result = await SqlMapper.ExecuteAsync(connection, "[dbo].[UpdateStockMaster]", parameter, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<IReadOnlyCollection<StockMaster>> GetAllAsyc()
        {
            using(var connection =new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await SqlMapper.QueryAsync<StockMaster>(connection, "[dbo].[GetStockMaster]", commandType: System.Data.CommandType.StoredProcedure);
                return result.AsList<StockMaster>();
            }
        }
    }
}

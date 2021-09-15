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
    public class StockTransactionRepository : IStockTransactionRepository
    {
        private readonly IConfiguration configuration;
        public StockTransactionRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public async Task<int> InsertAsyc(StockTransaction model)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@DocumentNo", model.DocumentNo);
                parameter.Add("@FK_TransactionTypeID", model.FK_TransactionTypeID);
                parameter.Add("@Qty", model.Qty);
                parameter.Add("@StockCode", model.StockCode);
                parameter.Add("@UnitCost", model.UnitCost);
                parameter.Add("@UnitSell", model.UnitSell);
                parameter.Add("@UnitSell", model.UnitSell);
                var result = await SqlMapper.ExecuteAsync(connection, "[dbo].[InsertDetorsTransaction]", parameter, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                return result;
            }
        }
        public async Task<int> UpdateAsyc(StockTransaction model)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@StockTransactionID", model.StockTransactionID);
                parameter.Add("@DocumentNo", model.DocumentNo);
                parameter.Add("@FK_TransactionTypeID", model.FK_TransactionTypeID);
                parameter.Add("@Qty", model.Qty);
                parameter.Add("@StockCode", model.StockCode);
                parameter.Add("@UnitCost", model.UnitCost);
                parameter.Add("@UnitSell", model.UnitSell);
                parameter.Add("@UnitSell", model.UnitSell);
                var result = await SqlMapper.ExecuteAsync(connection, "[dbo].[UpdateStockTransaction]", parameter, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                return result;
            }
        }
        public async Task<IReadOnlyCollection<StockTransaction>> GetByIDAysc(int stocmasterID)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@StockMasterID", stocmasterID);
                var result = await SqlMapper.QueryAsync<StockTransaction>(connection, "[dbo].[GetDetorTransactionByID]", parameter, commandType: System.Data.CommandType.StoredProcedure);
                return result.AsList<StockTransaction>();
            }
        }

    }
}

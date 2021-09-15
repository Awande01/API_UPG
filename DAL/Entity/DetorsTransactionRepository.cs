using BL.Interface;
using BL.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class DetorsTransactionRepository : IDetorsTransactionRepository
    {
        private readonly IConfiguration iconfiguarion;
        public DetorsTransactionRepository(IConfiguration _iconfiguarion)
        {
            iconfiguarion = _iconfiguarion;
        }

        public async Task<int> InsertAsyc(DetorsTransaction model)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@AccountCode ", model.AccountCode);
                parameter.Add("@FK_TransactionType", model.FK_TransactionType);
                parameter.Add("@DocumentNo", model.DocumentNo);
                parameter.Add("@GrossTransactionValue ", model.GrossTransactionValue);
                parameter.Add("@VatValue", model.VatValue);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[InsertDetorsTransaction]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<int> UpdateAsyc(DetorsTransaction model)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@DetorsTransactionID", model.DetorsTransactionID);
                parameter.Add("@AccountCode ", model.AccountCode);
                parameter.Add("@FK_TransactionType", model.FK_TransactionType);
                parameter.Add("@DocumentNo", model.DocumentNo);
                parameter.Add("@GrossTransactionValue ", model.GrossTransactionValue);
                parameter.Add("@VatValue", model.VatValue);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[UpdateDetorsTransaction]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<IReadOnlyCollection<DetorsTransaction>> GetByCodeAysc(string accountCode)
        {
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@AccountCode", accountCode);
                var result = await SqlMapper.QueryAsync<DetorsTransaction>(connection, "[dbo].[GetDetorTransaction]", parameter, commandType: CommandType.StoredProcedure);
                return result.AsList<DetorsTransaction>();
            }
        }
        public async Task<IReadOnlyCollection<DetorsTransaction>> GetByIDAysc(int detorsTransactionID)
        {
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@DetorsTransactionID", detorsTransactionID);
                var result = await SqlMapper.QueryAsync<DetorsTransaction>(connection, "[dbo].[GetDetorTransaction]", parameter, commandType: CommandType.StoredProcedure);
                return result.AsList<DetorsTransaction>();
            }
        }
    }
}


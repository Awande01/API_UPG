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
    public  class DetorsRepository : IDetorsMasterRepository
    {
        private readonly IConfiguration iconfiguarion;
        public DetorsRepository(IConfiguration _iconfiguarion)
        {
            iconfiguarion = _iconfiguarion;
        }

        public async Task<string> InsertAsyc(DetorsMaster model)
        {
            string result ;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@AccountCode",dbType:DbType.String,direction:ParameterDirection.Output,size: 5215585);
                parameter.Add("@Address1", model.Address1);
                parameter.Add("@Address2", model.Address2);
                parameter.Add("@Address3 ", model.Address3);
                parameter.Add("@Balance", model.Balance);
                parameter.Add("@SalesYearToDate", model.SalesYearToDate);
                parameter.Add("@CostYearToDate", model.CostYearToDate);
                await SqlMapper.ExecuteAsync(connection, "[dbo].[InsertDetorsMaster]", parameter, commandType: CommandType.StoredProcedure);
                result = parameter.Get<string>("@AccountCode");
                connection.Close();
            }
            return result;
        }
        public async Task<int> UpdateAsyc(DetorsMaster model)
        {
            int result = 0;
            using (var connection =new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@AccountCode ", model.AccountCode);
                parameter.Add("@Address1", model.Address1);
                parameter.Add("@Address2", model.Address2);
                parameter.Add("@Address3 ", model.Address3);
                parameter.Add("@Balance", model.Balance);
                parameter.Add("@SalesYearToDate", model.SalesYearToDate);
                parameter.Add("@CostYearToDate", model.CostYearToDate);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[UpdateDetorsMaster]", parameter, commandType: CommandType.StoredProcedure);
                connection.Close();
            }
            return result;
        }
        public async Task<IReadOnlyCollection<DetorsMaster>> GetByIDAysc(int id)
        {
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@DetorsMasterID ", id);
                var result = await SqlMapper.QueryAsync<DetorsMaster>(connection, "[dbo].[GetDetorsMasterByID]",parameter, commandType: CommandType.StoredProcedure);
                connection.Close();
                return result.AsList<DetorsMaster>();
            }   
        }
        public async Task<IReadOnlyList<DetorsMaster>> GetAllAsyc()
        {
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
               connection.Open();
               var result = await SqlMapper.QueryAsync<DetorsMaster>(connection, "[dbo].[GetDetorsMaster]", commandType: CommandType.StoredProcedure);
               connection.Close();
               return result.AsList<DetorsMaster>();
            }
        }

    }
}

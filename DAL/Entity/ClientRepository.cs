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
    public  class ClientRepository : IClientRepository
    {
        private readonly IConfiguration iconfiguarion;
        public ClientRepository(IConfiguration _iconfiguarion)
        {
            iconfiguarion = _iconfiguarion;
        }

        public async Task<int> InsertAsyc(Client model)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@FirstName", model.FirstName);
                parameter.Add("@LastName", model.LastName);
                parameter.Add("@FK_GenderID", model.FK_GenderID);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[InsertClient]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<int> UpdateAsyc(Client model)
        {
            int result = 0;
            using (var connection =new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@FirstName", model.FirstName);
                parameter.Add("@LastName", model.LastName);
                parameter.Add("@FK_GenderID", model.FK_GenderID);
                parameter.Add("@ClientID", model.ClientID);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[UpdateClient]", parameter, commandType: CommandType.StoredProcedure); 
            }
            return result;
        }
        public async Task<GetClientByClientID> GetByIDAysc(int clientID)
        {
            GetClientByClientID result = new GetClientByClientID();
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ClientID", clientID);
                result = await SqlMapper.QuerySingleOrDefaultAsync<GetClientByClientID>(connection, "[dbo].[GetClientByClientID]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<IReadOnlyList<GetClientByClientID>> GetAllAsyc()
        {
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
               var result = await SqlMapper.QueryAsync<GetClientByClientID>(connection, "[dbo].[GetAllClients]", commandType: CommandType.StoredProcedure);
               return result.AsList<GetClientByClientID>();
            }
        }
        public async Task<int> DeleteAsyc(int ClientID)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ClientID", ClientID);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[DeleteClient]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<IReadOnlyList<Gender>> GetGender()
        {
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                var result = await SqlMapper.QueryAsync<Gender>(connection, "[dbo].[GetGender]", commandType: CommandType.StoredProcedure);
                return result.AsList<Gender>();
            }
        }
    }
}

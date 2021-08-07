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
    public class ClientContactDetailsRepository : IClientContactDetailsRepository
    {
        private readonly IConfiguration iconfiguarion;
        public ClientContactDetailsRepository(IConfiguration _iconfiguarion)
        {
            iconfiguarion = _iconfiguarion;
        }

        public async Task<int> InsertAsyc(ClientDetails model)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@FK_ContactTypeID", model.FK_ContactTypeID);
                parameter.Add("@ContactInformation", model.ContactInformation);
                parameter.Add("@FK_ClientID", model.FK_ClientID);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[InsertClientContactDetails]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<int> UpdateAsyc(ClientDetails model)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters(); 
                parameter.Add("@FK_ContactTypeID", model.FK_ContactTypeID);
                parameter.Add("@ClientContactID", model.ClientContactID);
                parameter.Add("@ContactInformation", model.ContactInformation);
                parameter.Add("@FK_ClientID", model.FK_ClientID);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[UpdateClientContactDetails]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<IReadOnlyList<GetClientContactDetailsByClientID>> GetByIDAysc(int clientID)
        {
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ClientID", clientID);
                var result = await SqlMapper.QueryAsync<GetClientContactDetailsByClientID>(connection, "[dbo].[GetClientContactDetailsByClientID]", parameter, commandType: CommandType.StoredProcedure);
                return result.AsList<GetClientContactDetailsByClientID>();
            }
        }
        public async Task<int> DeleteAsyc(int ClientContactID)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ClientContactID", ClientContactID);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[DeleteClientContactDetails]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<IReadOnlyList<ContactTypes>> GetContactTypes()
        {
            using(var connection =new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                var result = await SqlMapper.QueryAsync<ContactTypes>(connection, "[dbo].[GetContactType]", commandType: CommandType.StoredProcedure);
                return result.AsList<ContactTypes>();
            }
        }
    }
}


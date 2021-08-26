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
   public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration iconfiguarion;
        public CustomerRepository(IConfiguration _iconfiguarion)
        {
            iconfiguarion = _iconfiguarion;
        }

        public async Task<int> InsertAsyc(Customer model)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@FK_TypeID", model.FK_TypeID);
                parameter.Add("@FirstName", model.FirstName);
                parameter.Add("@Surname", model.Surname);
                parameter.Add("@EmailAddress", model.EmailAddress);
                parameter.Add("@Cellphone", model.Cellphone);
                parameter.Add("@Amount", model.Amount);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[InsertCustomer]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<int> UpdateAsyc(Customer model)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@CustomerID", model.CustomerID);
                parameter.Add("@FirstName", model.FirstName);
                parameter.Add("@Surname", model.Surname);
                parameter.Add("@FK_TypeID", model.FK_TypeID);
                parameter.Add("@EmailAddress", model.EmailAddress);
                parameter.Add("@Cellphone", model.Cellphone);
                parameter.Add("@Amount", model.Amount);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[UpdateCustomer]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<Customer> GetByIDAysc(int customerID)
        {
            Customer result = new Customer();
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@CustomerID", customerID);
                result = await SqlMapper.QuerySingleOrDefaultAsync<Customer>(connection, "[dbo].[GetCustomerByCustomerID]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
        public async Task<IReadOnlyList<Customer>> GetAllAsyc()
        {
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                var result = await SqlMapper.QueryAsync<Customer>(connection, "[dbo].[GetCustomers]", commandType: CommandType.StoredProcedure);
                return result.AsList<Customer>();
            }
        }
        public async Task<int> DeleteAsyc(int customerID)
        {
            int result = 0;
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@CustomerID", customerID);
                result = await SqlMapper.ExecuteAsync(connection, "[dbo].[DeleteCustomer]", parameter, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<IReadOnlyList<Types>> GetTypes()
        {
            using (var connection = new SqlConnection(iconfiguarion.GetConnectionString("DefaultConnection")))
            {
                var result = await SqlMapper.QueryAsync<Types>(connection, "[dbo].[GetTypes]", commandType: CommandType.StoredProcedure);
                return result.AsList<Types>();
            }
        }
    }
}

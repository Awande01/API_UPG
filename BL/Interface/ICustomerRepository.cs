using BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IReadOnlyList<Model.Types>> GetTypes();
    }
}

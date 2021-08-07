using BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IClientContactDetailsRepository : IGenericRepository<ClientDetails>
    {
        Task<IReadOnlyList<GetClientContactDetailsByClientID>> GetByIDAysc(int id);
        Task<IReadOnlyList<ContactTypes>> GetContactTypes();
    }
}

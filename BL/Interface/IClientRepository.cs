using BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<GetClientByClientID> GetByIDAysc(int id);
        Task<IReadOnlyList<GetClientByClientID>> GetAllAsyc();
        Task<IReadOnlyList<Gender>> GetGender();
    }
}

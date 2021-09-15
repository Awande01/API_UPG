using BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IDetorsMasterRepository : IGenericRepository<DetorsMaster>
    {
        Task<string> InsertAsyc(DetorsMaster model);
        Task<IReadOnlyList<DetorsMaster>> GetAllAsyc();
    }
}

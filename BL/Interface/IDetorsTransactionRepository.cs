using BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IDetorsTransactionRepository : IGenericRepository<DetorsTransaction>
    {
        Task<int> InsertAsyc(DetorsTransaction model);
        Task<IReadOnlyCollection<DetorsTransaction>> GetByCodeAysc(string code);
    }
}

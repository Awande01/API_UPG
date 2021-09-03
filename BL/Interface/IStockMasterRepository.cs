using BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IStockMasterRepository :IGenericRepository<StockMaster>
    {
        Task<string> InsertAsyc(StockMaster model);
        Task<IReadOnlyCollection<StockMaster>> GetAllAsyc();
    }
}

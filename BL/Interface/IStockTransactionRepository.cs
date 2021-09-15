using BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public interface IStockTransactionRepository :IGenericRepository<StockTransaction>
    {
        Task<int> InsertAsyc(StockTransaction model);
    }
}

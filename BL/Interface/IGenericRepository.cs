using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public  interface  IGenericRepository<T> where T:class
    {
        Task<int> InsertAsyc(T model);
        Task<int> UpdateAsyc(T model);
        Task<int> DeleteAsyc(int ID);
        Task<T> GetByIDAysc(int id);
        Task<IReadOnlyList<T>> GetAllAsyc();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    public  interface  IGenericRepository<T> where T:class
    {

        Task<int> UpdateAsyc(T model);

    }
}

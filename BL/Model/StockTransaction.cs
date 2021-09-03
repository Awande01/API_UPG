using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Model
{
    public  class StockTransaction
    {
        public int StockTransactionID { get; set; }
        public string StockCode { get; set; }
        public int FK_TransactionTypeID { get; set; }
        public int DocumentNo { get; set; }
        public int Qty { get; set; }
        public int UnitCost { get; set; }
        public int UnitSell { get; set; }

    }
}

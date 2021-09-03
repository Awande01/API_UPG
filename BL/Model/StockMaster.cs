using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Model
{
    public class StockMaster
    {
        public int StockMasterID { get; set; }
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public decimal Cost { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal TotalPurchasesExclVat { get; set; }
        public decimal TotalSalesExclVat { get; set; }
        public int QtyPurchased { get; set; }
        public decimal QtySold { get; set; }
        public int StockOnHand { get; set; }
    }
}

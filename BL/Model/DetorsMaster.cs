using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Model
{
    public class DetorsMaster 
    {
        public int DetorsMasterID { get; set; }
        public string Address1 { get; set; }
        public string AccountCode { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public decimal Balance { get; set; }
        public decimal SalesYearToDate { get; set; }
        public decimal CostYearToDate { get; set; }
    }
}

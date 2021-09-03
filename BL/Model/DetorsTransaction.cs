using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Model
{
    public class DetorsTransaction
    {
        public int DetorsTransactionID { get; set; }
        public DateTime DateCreated { get; set; }
        public string AccountCode { get; set; }
        public int FK_TransactionType { get; set; }
        public int DocumentNo { get; set; }
        public decimal GrossTransactionValue { get; set; }
        public int VatValue { get; set; }
    }

}

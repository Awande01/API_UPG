using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Model
{
    public class Customer 
    {
        public int? CustomerID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int FK_TypeID { get; set; }
        public string EmailAddress { get; set; }
        public string Cellphone { get; set; }
        public decimal Amount { get; set; }
    }

}

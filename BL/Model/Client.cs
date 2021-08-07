using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Model
{
    public class Client 
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FK_GenderID { get; set; }
    }
    public class GetClientByClientID
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
    }
}

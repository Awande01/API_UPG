using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Model
{
    public class ClientDetails
    {
        public int ClientContactID { get; set; }
        public string ContactInformation { get; set; }
        public int FK_ContactTypeID { get; set; }
        public int FK_ClientID { get; set; }
    }
    public class GetClientContactDetailsByClientID
    {
        public int FK_ContactTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClientContactID { get; set; }
        public string ContactType { get; set; }
        public string ContactInformation { get; set; }
        public int FK_ClientID { get; set; }
    }
}

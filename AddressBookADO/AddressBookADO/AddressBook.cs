using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookADO
{
     public class AddressBook
     {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
     }
}

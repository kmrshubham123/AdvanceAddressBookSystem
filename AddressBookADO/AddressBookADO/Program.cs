using System;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book contact data using ADO.Net");
            AddressBookOperation book = new AddressBookOperation();
            book.GetAllData();
            Console.WriteLine();
            //UC3:insert contact
            AddressBook address = new AddressBook();
            address.FirstName = "Manoj";
            address.LastName = "Singh";
            address.address = "SabziBazaar";
            address.City = "Gulmarg";
            address.State = "Jammu";
            address.Zip = 23659;
            address.PhoneNumber = "+91-3269568645";
            address.Email = "Manojsingh@gmail.com";
            address.Type = "Family";
            Console.WriteLine();
            book.AddContact(address);
            book.GetAllData();
        }
    }
}

using System;
using System.Collections.Generic;

namespace LibraryData.LIBDBModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressStreet { get; set; }
        public decimal PhoneNumber { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZipcode { get; set; }

        public Users EmployeeNavigation { get; set; }
    }
}

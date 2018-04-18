using System;
using System.Collections.Generic;

namespace LibraryMS.LIBDBModels
{
    public partial class Employee
    {
        public Employee()
        {
            Manages = new HashSet<Manages>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressStreet { get; set; }
        public decimal PhoneNumber { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZipcode { get; set; }

        public Users EmployeeNavigation { get; set; }
        public ICollection<Manages> Manages { get; set; }
    }
}

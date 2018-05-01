using System;
using System.Collections.Generic;

namespace LibraryData.LIBDBModels
{
    public class Users
    {
        public string PasswordHash { get; set; }
        public int? AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public DateTime? LastLoginAttempt { get; set; }
        public int UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressZipcode { get; set; }
        public decimal PhoneNumber { get; set; }
        public string AddressState { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? MembershipDate { get; set; }
        public int User_Status { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public UserType UserTypeNavigation { get; set; }
        //public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}

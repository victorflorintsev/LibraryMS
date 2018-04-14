using System;
using System.Collections.Generic;

namespace LibraryData.LIBDBModels
{
    public class Customer
    {

        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CustomerId { get; set; }
        public decimal PhoneNumber { get; set; }
        public DateTime MembershipIssued { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZipcode { get; set; }
        public int CustomerType { get; set; }

        public virtual Users CustomerNavigation { get; set; }
        public virtual CustomerType CustomerTypeNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace LibraryMS.LIBDBModels
{
    public partial class Customer
    {
        public Customer()
        {
            Borrow = new HashSet<Borrow>();
            IsWaitlistedBy = new HashSet<IsWaitlistedBy>();
        }

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

        public Users CustomerNavigation { get; set; }
        public CustomerType CustomerTypeNavigation { get; set; }
        public ICollection<Borrow> Borrow { get; set; }
        public ICollection<IsWaitlistedBy> IsWaitlistedBy { get; set; }
    }
}

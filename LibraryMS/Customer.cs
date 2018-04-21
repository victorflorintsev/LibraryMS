using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Customer
    {
        public Customer()
        {
            Borrow = new HashSet<Borrow>();
            Fine = new HashSet<Fine>();
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
        public string Username { get; set; }

        public Users UsernameNavigation { get; set; }
        public ICollection<Borrow> Borrow { get; set; }
        public ICollection<Fine> Fine { get; set; }
        public ICollection<IsWaitlistedBy> IsWaitlistedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryMS
{
    public partial class Users
    {
        public Users()
        {
            Borrow = new HashSet<Borrow>();
            Employee = new HashSet<Employee>();
            Fine = new HashSet<Fine>();
            IsWaitlistedBy = new HashSet<IsWaitlistedBy>();
        }

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

        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        public decimal? PhoneNumber { get; set; }

        public string AddressState { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Birthday { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? MembershipDate { get; set; }

        public UserType UserTypeNavigation { get; set; }
        public ICollection<Borrow> Borrow { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Fine> Fine { get; set; }
        public ICollection<IsWaitlistedBy> IsWaitlistedBy { get; set; }
    }
}

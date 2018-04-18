using System;
using System.Collections.Generic;

namespace LibraryMS.LIBDBModels
{
    public partial class Users
    {
        public int UsernameId { get; set; }
        public string HashedPassword { get; set; }
        public int FailedAttempts { get; set; }
        public string UsernameString { get; set; }
        public DateTime? LastLoginAttempt { get; set; }
        public int? UserType { get; set; }

        public UserType UserTypeNavigation { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}

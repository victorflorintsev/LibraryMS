using System;
using System.Collections.Generic;

namespace LibraryData.LIBDBModels
{
    public class UserType
    {
        public UserType()
        {
            Users = new HashSet<Users>();
        }

        public int UserTypeId { get; set; }
        public string UserTypeString { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}

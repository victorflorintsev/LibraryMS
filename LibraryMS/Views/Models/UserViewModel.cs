using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Views.Models
{
    public class UserViewModel
    {
        public Fine Fine { get; set; }
        public IsWaitlistedBy waitlist { get; set; }
        public IEnumerable<Users> User { get; set; }
    }
}

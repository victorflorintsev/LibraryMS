using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Employee
    {
        public Employee()
        {
            Manages = new HashSet<Manages>();
        }

        public int EmployeeId { get; set; }
        public string UserName { get; set; }

        public Users UserNameNavigation { get; set; }
        public ICollection<Manages> Manages { get; set; }
    }
}

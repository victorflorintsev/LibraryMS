using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Manages
    {
        public int EmployeeId { get; set; }
        public int SectionId { get; set; }
        public int PkId { get; set; }

        public Employee Employee { get; set; }
        public Section Section { get; set; }
    }
}

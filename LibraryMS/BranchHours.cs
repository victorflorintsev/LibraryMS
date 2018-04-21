using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class BranchHours
    {
        public int Id { get; set; }
        public int? BranchId { get; set; }
        public int CloseTime { get; set; }
        public int DayOfWeek { get; set; }
        public int OpenTime { get; set; }

        public LibraryBranches Branch { get; set; }
    }
}

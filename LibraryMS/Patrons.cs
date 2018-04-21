using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Patrons
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public int? HomeLibraryBranchId { get; set; }
        public string LastName { get; set; }
        public int LibraryCardId { get; set; }
        public string Telephone { get; set; }

        public LibraryBranches HomeLibraryBranch { get; set; }
        public LibraryCards LibraryCard { get; set; }
    }
}

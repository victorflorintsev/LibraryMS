using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class LibraryBranches
    {
        public LibraryBranches()
        {
            BranchHours = new HashSet<BranchHours>();
            LibraryAssets = new HashSet<LibraryAssets>();
            Patrons = new HashSet<Patrons>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }
        public string Telephone { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<BranchHours> BranchHours { get; set; }
        public ICollection<LibraryAssets> LibraryAssets { get; set; }
        public ICollection<Patrons> Patrons { get; set; }
    }
}

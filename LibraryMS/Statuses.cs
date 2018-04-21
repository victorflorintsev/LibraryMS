using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Statuses
    {
        public Statuses()
        {
            LibraryAssets = new HashSet<LibraryAssets>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public ICollection<LibraryAssets> LibraryAssets { get; set; }
    }
}

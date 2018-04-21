using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Section
    {
        public Section()
        {
            Located = new HashSet<Located>();
            Manages = new HashSet<Manages>();
        }

        public int SectionId { get; set; }
        public string LocationString { get; set; }
        public string SectionName { get; set; }
        public string StartCallNum { get; set; }
        public string EndCallNum { get; set; }

        public ICollection<Located> Located { get; set; }
        public ICollection<Manages> Manages { get; set; }
    }
}

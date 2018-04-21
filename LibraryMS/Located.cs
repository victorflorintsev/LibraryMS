using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Located
    {
        public int MediaId { get; set; }
        public int SectionId { get; set; }
        public int PkId { get; set; }

        public Media Media { get; set; }
        public Section Section { get; set; }
    }
}

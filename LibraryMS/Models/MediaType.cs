using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class MediaType
    {
        public MediaType()
        {
            Media = new HashSet<Media>();
        }

        public int MediaTypeId { get; set; }
        public string MediaTypeName { get; set; }

        public ICollection<Media> Media { get; set; }
    }
}

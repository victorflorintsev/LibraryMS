using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class IsWaitlistedBy
    {
        public int PositionNum { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CustomerId { get; set; }
        public int MediaId { get; set; }
        public int PkId { get; set; }

        public Customer Customer { get; set; }
        public Media Media { get; set; }
    }
}

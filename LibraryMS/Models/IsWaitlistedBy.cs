using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class IsWaitlistedBy
    {
        public int PositionNum { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string UserName { get; set; }
        public int MediaId { get; set; }
        public int PkId { get; set; }

        public Media Media { get; set; }
        public Users UserNameNavigation { get; set; }
    }
}

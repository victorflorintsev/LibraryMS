using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Borrow
    {
        public string UserName { get; set; }
        public int MediaId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int PkId { get; set; }

        public Media Media { get; set; }
        public Users UserNameNavigation { get; set; }
    }
}

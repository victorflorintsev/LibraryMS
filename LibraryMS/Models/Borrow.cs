using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryMS
{
    public partial class Borrow
    {
        public string UserName { get; set; }
        public int MediaId { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime IssueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DueDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? ReturnDate { get; set; }

        public int PkId { get; set; }

        public Media Media { get; set; }
        public Users UserNameNavigation { get; set; }
    }
}

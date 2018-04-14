using System;
using System.Collections.Generic;

namespace LibraryMS.LIBDBModels
{
    public partial class Media
    {
        public int MediaId { get; set; }
        public int Isbn { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public int MediaType { get; set; }
        public string CallNum { get; set; }
        public DateTime DateAdded { get; set; }
        public int CopiesLeft { get; set; }
        public int MaxCopies { get; set; }

        public MediaType MediaNavigation { get; set; }
    }
}

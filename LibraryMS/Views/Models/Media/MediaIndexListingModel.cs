using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Models.Media
{
    public class MediaIndexListingModel 
    {
        public int Id { get; set; } //media ID
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int Type { get; set; }
        public string CallNum { get; set; }
        public int CopiesLeft { get; set; }
    }
}

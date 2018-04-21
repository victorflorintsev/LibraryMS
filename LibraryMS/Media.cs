using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Media
    {
        public Media()
        {
            Borrow = new HashSet<Borrow>();
            IsWaitlistedBy = new HashSet<IsWaitlistedBy>();
            Located = new HashSet<Located>();
        }

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

        public MediaType MediaTypeNavigation { get; set; }
        public ICollection<Borrow> Borrow { get; set; }
        public ICollection<IsWaitlistedBy> IsWaitlistedBy { get; set; }
        public ICollection<Located> Located { get; set; }
    }
}

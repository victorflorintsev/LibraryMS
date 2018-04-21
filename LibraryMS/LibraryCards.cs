using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class LibraryCards
    {
        public LibraryCards()
        {
            CheckoutHistories = new HashSet<CheckoutHistories>();
            Checkouts = new HashSet<Checkouts>();
            Holds = new HashSet<Holds>();
            Patrons = new HashSet<Patrons>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal Fees { get; set; }

        public ICollection<CheckoutHistories> CheckoutHistories { get; set; }
        public ICollection<Checkouts> Checkouts { get; set; }
        public ICollection<Holds> Holds { get; set; }
        public ICollection<Patrons> Patrons { get; set; }
    }
}

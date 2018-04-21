using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class LibraryAssets
    {
        public LibraryAssets()
        {
            CheckoutHistories = new HashSet<CheckoutHistories>();
            Checkouts = new HashSet<Checkouts>();
            Holds = new HashSet<Holds>();
        }

        public int Id { get; set; }
        public decimal Cost { get; set; }
        public string Discriminator { get; set; }
        public string ImageUrl { get; set; }
        public int? LocationId { get; set; }
        public int NumberOfCopies { get; set; }
        public int StatusId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string DeweyIndex { get; set; }
        public string Isbn { get; set; }
        public string Director { get; set; }

        public LibraryBranches Location { get; set; }
        public Statuses Status { get; set; }
        public ICollection<CheckoutHistories> CheckoutHistories { get; set; }
        public ICollection<Checkouts> Checkouts { get; set; }
        public ICollection<Holds> Holds { get; set; }
    }
}

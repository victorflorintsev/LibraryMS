using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class Fine
    {
        public int CustomerId { get; set; }
        public bool? HasPaid { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public int PkId { get; set; }

        public Customer Customer { get; set; }
    }
}

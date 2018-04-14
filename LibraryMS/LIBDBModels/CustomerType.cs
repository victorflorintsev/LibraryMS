using System;
using System.Collections.Generic;

namespace LibraryMS.LIBDBModels
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customer = new HashSet<Customer>();
        }

        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public int BookLimit { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}

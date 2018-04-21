using System;
using System.Collections.Generic;

namespace LibraryMS
{
    public partial class CustomerType
    {
        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public int BookLimit { get; set; }
    }
}
